<template>
  <div v-if="get">
    <button v-if="width>768" class="btn btn-danger d-none show-message" @click="removeJoin">顯示聊天清單</button>
    <div v-for="item in messages" :key="item.id">
      <div class="brief hide-message" @click="sendData(item)">
        <a v-if="width<768" class="messageBox" data-bs-toggle="offcanvas" href="#offcanvasRight" role="button"
           aria-controls="offcanvasRight">
          <div class="row d-flex align-items-center py-2">
            <div class="col-2">
              <div class="img"><img :src="getReceiver(item).portrait"></div>
            </div>
            <div class="col-8 text">
              <div class="name">[{{ getReceiver(item).nickname }}] {{ getReceiver(item).name }}</div>
              <div class="message" v-if="getMessage(item).content.length<=12">{{ getMessage(item).content }}</div>
              <div class="message" v-else>{{ getMessage(item).content.slice(0, 12) }}...</div>
              <div class="bookingDate">{{ item.tourDetail.startDate.split('T')[0] }} 至
                {{ item.tourDetail.endDate.split('T')[0] }}
              </div>
            </div>
            <div class="col-2 info d-flex flex-column align-items-center">
              <div class="lastestDate">
                {{
                  getMessage(item).time.split('T')[0].split('-')[1]
                }}/{{ getMessage(item).time.split('T')[0].split('-')[2] }}
              </div>
              <div class="uncheck" v-if="item.memberId == item.landlord.id && item.memberOneStatus != 0">
                {{ item.memberOneStatus }}
              </div>
              <div class="uncheck" v-else-if="item.memberId != item.landlord.id && item.memberTwoStatus != 0">
                {{ item.memberTwoStatus }}
              </div>
            </div>
          </div>
        </a>
        <a v-else class="messageBox">
          <div class="row d-flex align-items-center py-2">
            <div class="col-2">
              <div class="img"><img :src="getReceiver(item).portrait"></div>
            </div>
            <div class="col-8 text">
              <div class="name">[{{ getReceiver(item).nickname }}] {{ getReceiver(item).name }}</div>
              <div class="message" v-if="getMessage(item).content.length<=12">{{ getMessage(item).content }}</div>
              <div class="message" v-else>{{ getMessage(item).content.slice(0, 12) }}...</div>
              <div class="bookingDate">{{ item.tourDetail.startDate.split('T')[0] }} 至
                {{ item.tourDetail.endDate.split('T')[0] }}
              </div>
            </div>
            <div class="col-2 info d-flex flex-column align-items-center">
              <div class="lastestDate">
                {{
                  getMessage(item).time.split('T')[0].split('-')[1]
                }}/{{ getMessage(item).time.split('T')[0].split('-')[2] }}
              </div>
              <div class="uncheck" v-if="item.memberId == item.landlord.id && item.memberOneStatus != 0">
                {{ item.memberOneStatus }}
              </div>
              <div class="uncheck" v-else-if="item.memberId != item.landlord.id && item.memberTwoStatus != 0">
                {{ item.memberTwoStatus }}
              </div>
            </div>
          </div>
        </a>
      </div>
    </div>
    <div v-if="width<768" class="offcanvas offcanvas-end" data-bs-scroll="true" tabindex="-1" id="offcanvasRight"
         aria-labelledby="offcanvasRightLabel">
      <div class="offcanvas-header d-flex flex-column align-items-start p-0">
        <div class="d-flex justify-content-start align-items-center py-3">
          <button type="button" class="btn d-flex align-items-center" data-bs-dismiss="offcanvas" aria-label="Close"
                  @click="removeJoin">
            <img src="../../assets/image/Room/icon/back.svg"/>
          </button>
          <div class="title">
            <div class=" d-flex">
              <h2 id="offcanvasRightLabel" v-if="Object.keys(mes).length != 0">[{{ getReceiver(mes).nickname }}]
                {{ getReceiver(mes).name }}</h2>
              <span v-if="count==2" class="ms-2"><i class="fas fa-circle text-success"></i> (上線中)</span>
              <span v-else class="ms-2"><i class="fas fa-circle text-danger"></i> (未上線)</span>
            </div>
            <div>回覆時間：1 小時</div>
          </div>
        </div>
        <a href="#" class="row mix d-flex w-100  p-3 align-items-center" @click.prevent="goRoom">
          <div class="col-2">
            <div class="img" v-if="Object.keys(mes).length != 0"><img :src="mes.pictures[0]"></div>
          </div>
          <div class="col-10 text-start">
            <h3 v-if="Object.keys(mes).length != 0">{{ mes.tourDetail.title.slice(0, 20) }}...</h3>
            <div class="bookingDate" v-if="Object.keys(mes).length != 0">{{ mes.tourDetail.startDate.split('T')[0] }} 至
              {{ mes.tourDetail.endDate.split('T')[0] }}
            </div>
          </div>
        </a>
      </div>
      <div class="offcanvas-body">
        <Talk :message="mes"></Talk>
        <Signal :message="mes"></Signal>
      </div>
      <div class="offcanvas-footer">
        <div class="input"><input type="text" v-model="msg" placeholder="輸入訊息" @keydown.enter="sengMsg"></div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import Talk from '../Information/Talk';
import Signal from '../Information/SignalMessage';
import * as signalR from '@microsoft/signalr';
import moment from 'moment';
import settingJson from "@/components/Settings/setting";

let hubUrl = "http://airelax.azurewebsites.net/chathub";
const connection = new signalR.HubConnectionBuilder().withUrl(hubUrl, {
  skipNegotiation: true,
  transport: signalR.HttpTransportType.WebSockets
}).build();

export default {
  components: {Talk, Signal},
  data() {
    return {
      mes: {},
      receiver: "",
      msg: "",
      count: 0,
      setting: settingJson,
      messages: {},
      get: false
    }
  },
  computed: {
    width() {
      return this.$store.state.fullWidth;
    }
  },
  mounted() {
    var vm = this;
    console.log("10-03 20:10")
    console.log(connection)
    console.log("get Start")
    connection.start().then(() => {
      console.log("get Into Start")
      console.log(connection)
      vm.$store.state.connection = connection;
      vm.startUp();
      vm.detectStatus();
    }).catch(err => console.log(err));
  },
  updated() {
    this.scrollToBottom();
  },
  methods: {
    detectStatus() {
      var vm = this;
      connection.on("ReceiveStatus", function (objString) {
        var objItem = JSON.parse(objString);
        let ontime = {
          MemberId: objItem.memberId,
          OtherId: objItem.gusetId
        }
        for (let i = 0; i < vm.messages.length; i++) {
          if (vm.messages[i].gusetId == objItem.memberId) {
            connection.invoke("GetCount", vm.mes.connectString).then(x => {
              vm.count = x
              if (vm.count == 2) {
                vm.mes.memberOneStatus = 0;
                vm.mes.memberTwoStatus = 0;
                vm.$store.state.unreadCount = 0;
              }
            })
            break;
          } else if (vm.messages[i].memberId == objItem.memberId) {
            connection.invoke("GetCount", vm.mes.connectString).then(x => {
              vm.count = x;
              if (vm.count != 2) {
                vm.updateStatus(ontime);
              }
            })
            break;
          }
        }
      })
    },
    startUp() {
      var vm = this;
      vm.$store.state.unreadCount = 0;
      vm.$store.state.signalCommunications = [];

      axios.get(`/api/messages/${vm.$store.state.login.memberId}`, {
        headers: {"Access-Control-Allow-Origin": "*",}
      })
          .then((res) => {
            vm.messages = res.data;
            vm.messages.forEach(x => {
              vm.getFake(x)
              connection.invoke("AddAllGroup", x.connectString);
            })
            vm.get = true;
            console.log(vm.messages)
          });

      connection.on("ReceiveMessage", function (objString, message) {
        var objItem = JSON.parse(objString);

        let com = {
          senderId: objItem.memberId,
          receiverId: objItem.gusetId,
          content: message,
          time: moment(new Date()).format('YYYY-MM-DD[T]HH:mm:ss')
        }

        let ontime = {
          MemberId: objItem.memberId,
          OtherId: objItem.gusetId
        }

        for (let i = 0; i < vm.messages.length; i++) {
          if (vm.messages[i].gusetId == objItem.memberId) {
            if (Object.keys(vm.mes).length != 0) {
              vm.$store.state.signalCommunications.push(com);
            }
            connection.invoke("GetCount", vm.mes.connectString).then(x => {
              vm.count = x
              if (vm.count == 2) {
                vm.mes.memberOneStatus = 0;
                vm.mes.memberTwoStatus = 0;
                vm.$store.state.unreadCount = 0;
              } else {
                setTimeout(() => {
                  vm.getData();
                }, 1000);
              }
            })
            vm.scrollToBottom();
            break;
          } else if (vm.messages[i].memberId == objItem.memberId) {
            vm.$store.state.signalCommunications.push(com);
            axios.put(`/api/messages/${vm.$route.params.memberId}/content`, com, {
              headers: {
                "Access-Control-Allow-Origin": "*",
              }
            }).then(() => {

              connection.invoke("GetCount", vm.mes.connectString).then(x => {
                vm.count = x
                if (vm.count === 2) {
                  vm.updateStatus(ontime);
                  vm.mes.memberOneStatus = 0;
                  vm.mes.memberTwoStatus = 0;
                  vm.$store.state.unreadCount = 0;
                } else {
                  axios.put(`/api/messages/${vm.$route.params.memberId}/ontime`, ontime, {
                    headers: {
                      "Access-Control-Allow-Origin": "*",
                    }
                  }).then(function () {
                    vm.getData();
                  })
                  vm.$store.state.unreadCount += 1;
                }
              })
            });
            vm.scrollToBottom();
            break;
          }
        }
      })
    },
    getData() {
      var vm = this;
      axios.get(`/api/messages/${vm.$route.params.memberId}`, {
        headers: {"Access-Control-Allow-Origin": "*",},
      }).then((res) => {
        vm.messages = res.data;
        vm.messages.forEach(x => {
          vm.getFake(x)
        })
      });
    },
    updateStatus(ontime) {
      var vm = this;
      axios.put(`/api/messages/${vm.$route.params.memberId}/status`, ontime, {
        headers: {
          "Access-Control-Allow-Origin": "*",
        }
      }).then(function () {
        vm.getData();
      }).catch(err => {
        console.log(err)
      })
    },
    sengMsg() {
      var vm = this;
      connection.invoke("SendMessageToGroup", vm.mes.connectString, JSON.stringify(vm.mes), vm.msg)
      vm.msg = "";
    },
    removeJoin() {
      var vm = this;
      if (vm.width > 768) {
        document.querySelectorAll('.hide-message').forEach(x => {
          x.classList.remove('d-none')
        });
        document.querySelector('.show-message').classList.add('d-none');
        vm.$store.state.message = {};
      }

      connection.invoke("OnlineStatus", vm.mes.connectString, JSON.stringify(vm.mes))

      connection.invoke("RemoveGroup", vm.mes.connectString).then(() => {
        vm.$store.state.signalCommunications = [];
        vm.$store.state.unreadCount = 0;
        vm.count = 0;
        vm.messages.forEach(x => {
          connection.invoke("AddAllGroup", x.connectString);
        });
        vm.getData();
      })
    },
    sendData(item) {
      var vm = this;

      vm.mes = item;
      vm.$store.state.message = item;

      vm.messages.forEach(x => {
        connection.invoke("RemoveAllGroup", x.connectString);
      })

      vm.$nextTick(() => {
        vm.$store.state.signalCommunications = [];
        connection.invoke("AddGroup", item.connectString).then(() => {
          connection.invoke("OnlineStatus", vm.mes.connectString, JSON.stringify(vm.mes))
        })
      });

      //已讀
      let com = {
        MemberId: item.memberId,
        OtherId: item.gusetId
      }
      if (item.memberId == item.landlord.id) {
        if (item.memberOneStatus != 0) vm.updateStatus(com);
      } else {
        if (item.memberTwoStatus != 0) vm.updateStatus(com);
      }

      if (vm.width > 768) {
        document.querySelectorAll('.hide-message').forEach(x => {
          x.classList.add('d-none')
        })
        document.querySelector('.show-message').classList.remove('d-none');
      }
    },
    getReceiver(item) {
      if (item.memberId == item.landlord.id) {
        return {
          id: "",
          name: item.name,
          portrait: item.portrait,
          nickname: "房客"
        }
      } else {
        return {
          id: item.landlord.id,
          name: item.landlord.name,
          portrait: item.landlord.cover,
          nickname: "房東"
        }
      }
    },
    getMessage(item) {
      return item.communications[item.communications.length - 1]
    },
    goRoom() {
      this.$router.push({
        path: `/room/${this.mes.landlord.houseId}`,
      });
    },
    scrollToBottom() {
      this.$nextTick(() => {
        let offBody = document.querySelector('.offcanvas-body');
        let body = document.querySelector('.body');
        if (offBody != null) {
          offBody.scrollTop = offBody.scrollHeight;
        }
        if (body != null) {
          body.scrollTop = body.scrollHeight;
        }
      })
    },
    getRandomNumber(min, max) {
      return Math.floor(Math.random() * (max - min + 1)) + min;
    },
    getRandomList(min, max, num) {
      var list = [];
      while (list.length != num) {
        var randomNumber = Math.floor(Math.random() * (max - min + 1)) + min;
        if (!list.some((x) => {
          return x == randomNumber;
        })
        ) {
          list.push(randomNumber);
        }
      }
      return list;
    },
    //Todo-先給隨機LandlordCover資料
    getLandlordCover(messages) {
      if (messages.landlord.cover !== null) return;
      let num = this.getRandomList(0, this.setting.portraits.length - 1, 1)[0];
      messages.landlord.cover = this.setting.portraits[num];
    },
    //Todo-先給隨機Portrait資料
    getPortrait(messages) {
      if (messages.portrait !== null) return;
      let num = this.getRandomList(0, this.setting.portraits.length - 1, 1)[0];
      messages.portrait = this.setting.portraits[num];
    },
    //Todo-先給隨機Price資料
    getPrice(messages) {
      if (messages.paymentDetail.serviceFee !== 0) return;
      Object.keys(messages.paymentDetail).forEach(x => {
        messages.paymentDetail[x] = Math.round(messages.origin * 0.1 + this.getRandomNumber(1, messages.origin / 5));
      });
    },
    //Todo-先給隨機Picture資料
    getPicture(messages) {
      if (messages.pictures.length !== 0) return;
      let num = this.getRandomList(0, this.setting.pictures.length - 1, 1)[0];
      messages.pictures.push(this.setting.pictures[num]);
    },
    getFake(x) {
      this.getLandlordCover(x);
      this.getPortrait(x);
      this.getPrice(x);
      this.getPicture(x);
    }
  },
}
</script>

<style lang="scss" scoped>
.brief {
  cursor: pointer;

  &:hover {
    background-color: rgb(226, 222, 222);
  }

  &.active {
    background-color: rgb(226, 222, 222);
  }
}

.messageBox {
  text-align: start;
  border-bottom: 1px solid rgb(209, 206, 206);
  color: #000;
  text-decoration: none;

  .img {
    img {
      width: 100%;
      vertical-align: bottom;
      object-fit: cover;
      border-radius: 50%;
    }
  }

  .text {
    padding-left: 0.5rem;

    div {
      margin: 0.5rem 0;
    }

    .name,
    .bookingDate {
      font-size: 0.9rem;
    }
  }

  .info {
    text-align: center;

    .uncheck {
      margin-top: 0.3rem;
      height: 1.8rem;
      width: 1.8rem;
      line-height: 1.8rem;
      font-weight: 700;
      background-color: #ff385c;
      border-radius: 50%;
      color: #fff;
    }
  }
}

#offcanvasRight {
  border-left: none;
  width: 100%;

  img {
    width: 1.5rem;
  }

  .title {
    text-align: start;
    margin-left: 1rem;

    h2 {
      font-weight: 700;
    }
  }

  .mix {
    color: #000;
    text-decoration: none;
    border-top: 1px solid rgba(123, 123, 123, 0.2);
    border-bottom: 1px solid rgba(123, 123, 123, 0.2);

    img {
      width: 2.5rem;
      height: 2.5rem;
      vertical-align: bottom;
      object-fit: cover;
      border-radius: 8px;
    }

    h3 {
      font-weight: 900;
      text-decoration: underline !important;
      margin-bottom: 0.5em;
    }

    .bookingDate {
      font-size: 0.9rem;
    }
  }

  .offcanvas-footer {
    background-color: #fff;
    height: 6rem;
    display: flex;
    align-items: center;
    justify-content: center;

    input {
      border-radius: 30px;
      border: 1px solid rgb(123, 123, 123);
      padding: .7rem .5rem;
      width: 85vw;
      font-size: 1.1rem;

      &:focus {
        border: 2px solid rgb(0, 0, 0);
      }
    }
  }
}

@media screen and (min-width: 768px) {
  .brief {
    padding: 0 0.8rem;
  }
}
</style>