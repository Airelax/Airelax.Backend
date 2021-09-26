<template>
  <div v-if="get" class="top">
    <Share v-if="fullWidth < 768"></Share>
    <Picture
        :pic="data.pictures"
        v-if="fullWidth < 768"
        data-bs-toggle="modal"
        data-bs-target="#myModal"
        @click="isPicShow = true"
    ></Picture>
    <div class="gap">
      <div class="mix-detail">
        <h1>{{ data.title }}</h1>
        <div class="mix-md d-flex">
          <div class="remix">
            <i class="fas fa-star"></i>
            <span class="num">{{ data.rank.star.toFixed(2) }}</span>
            <a href="#" @click.prevent="isCommentShow = true" @click="show" data-bs-toggle="modal"
               data-bs-target="#myModal">({{ data.comments.length }}則評論)</a>
            <span class="dot">·</span>
            <a href="#location"
            ><span
            >{{ data.locationDto.town }}、{{ data.locationDto.city }}、{{
                data.locationDto.country
              }}</span
            ></a
            >
          </div>
          <Share v-if="fullWidth > 768"></Share>
        </div>
      </div>
      <Picture :pic="data.pictures" v-if="fullWidth > 768"></Picture>
      <div class="row sticky-section">
        <div class="col-12 col-md-7">
          <div class="landlord-brief">
            <div class="house">
              <div class="txt">
                <h2 v-if="fullWidth > 768">
                  {{ data.owner.name }}出租的整套出租住所
                </h2>
                <div v-if="fullWidth < 768">
                  <p>整套出租住所</p>
                  <p>房東 : {{ data.owner.name }}</p>
                </div>
              </div>
              <a class="img" href="#landlord">
                <img :src="data.owner.cover" style="width: 3rem;"/>
              </a>
            </div>
            <div class="detail">
              <span
              >{{ data.space.customerNumber }}位 ·
                {{ data.space.bedroom }}間臥室 · {{ data.space.bed }}張床 ·
                {{ data.space.bathroom }}間衛浴</span
              >
            </div>
          </div>

          <div class="honor">
            <ul>
              <li v-for="item in data.honor" :key="item.type">
                <img :src="item.img" style="width:1.5rem;">
                <div class="detail">
                  <p>{{ item.chinese }}</p>
                  <span>{{ item.description }}</span>
                </div>
              </li>
            </ul>
          </div>

          <div class="description">
            <p>{{ data.description.houseDescription }}</p>
            <a
                data-bs-toggle="modal"
                data-bs-target="#myModal"
                @click="isDescShow = true"
            >顯示更多內容 ></a
            >
          </div>

          <Bed :bedroom="data.bedroomDetail"></Bed>

          <div class="facility">
            <h2>有提供的設備與服務</h2>
            <ul>
              <div class="row">
                <div class="col-12 col-md-6 hide">
                  <div v-for="item in data.facility.provide" :key="item" class="d-flex align-items-center">
                    <li v-if="checkFacilityItem(item)">
                      <img :src="getFacilityIcon(item)" style="width:1.5rem;">
                      <span>{{ getFacilityName(item) }}</span>
                    </li>
                  </div>
                </div>
              </div>
            </ul>
            <a
                data-bs-toggle="modal"
                data-bs-target="#myModal"
                @click="isFacilityShow = true"
            >顯示全部{{ data.facility.provide.length }}項設備與服務</a
            >
          </div>
          <Location :detail="data.locationDto" v-if="fullWidth < 768"></Location>
          <div class="dateBottom">
            <keep-alive>
              <Date></Date>
            </keep-alive>
          </div>
        </div>
        <div class="col-12 col-md-5 price-sticky">
          <div class="price">
            <div class="mix">
              <p>
                ${{
                  data.price.origin
                      .toFixed(0)
                      .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
                }}
                / 晚
              </p>
              <div>
                <i class="fas fa-star"></i>
                <span class="num">{{ data.rank.star.toFixed(2) }}</span>
                <a href="#" @click.prevent="isCommentShow = true" @click="show" data-bs-toggle="modal"
                   data-bs-target="#myModal">({{ data.comments.length }}則評論)</a>
              </div>
            </div>

            <keep-alive>
              <DatePicker v-if="fullWidth > 768"></DatePicker>
            </keep-alive>

            <button
                v-if="Object.keys($store.state.date).length === 0"
                data-bs-toggle="modal"
                data-bs-target="#myModal"
                @click="isDateShow = true"
            >
              查看可訂日期
            </button>
            <button v-else @click="goSubscribe">預定</button>

            <div
                class="hide-price"
                v-if="
                fullWidth > 768 && Object.keys($store.state.date).length !== 0
              "
            >
              <div class="price-show">
                <p>
                  ${{
                    data.price.origin
                        .toFixed(0)
                        .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
                  }}
                  X {{ $store.state.nightCount }}晚
                </p>
                <span
                >${{
                    (data.price.origin * $store.state.nightCount)
                        .toFixed(0)
                        .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
                  }}</span
                >
              </div>
              <div class="price-show">
                <p>清潔費</p>
                <span>${{ data.price.fee.cleanFee.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ",") }}</span>
              </div>
              <div class="price-show">
                <p>服務費</p>
                <span>${{ data.price.fee.serviceFee.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ",") }}</span>
              </div>
              <div class="price-show">
                <p>稅額</p>
                <span>${{ data.price.fee.taxFee.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ",") }}</span>
              </div>
              <div class="price-total">
                <p>總價</p>
                <span
                >${{
                    (data.price.origin * $store.state.nightCount + data.price.fee.cleanFee + data.price.fee.serviceFee + data.price.fee.taxFee).toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ",")
                  }}</span
                >
              </div>
            </div>
          </div>
        </div>
      </div>

      <!-- sticky -->

      <Comment @Show="CommentShow" :comment="data.comments" :rank="data.rank"></Comment>

      <Location :detail="data.locationDto" v-if="fullWidth > 768"></Location>

      <div class="row landlord-section" id="landlord">
        <div class="col-12 col-md-6">
          <div class="landlord">
            <div class="detail">
              <div class="txt">
                <p>房東 : {{ data.owner.name }}</p>
                <span>加入時間 : {{ data.owner.registerTime.split('T')[0] }}</span>
              </div>
              <a class="img" :href="'/MemberInfo/'+data.owner.id">
                <img :src="data.owner.cover" style="width: 3rem;"/>
              </a>
            </div>
            <div class="mix">
              <p>
                <i class="fas fa-star"></i> {{ data.owner.totalComments }}則評論
              </p>
              <p><i class="fas fa-user-shield"></i>身分已驗證</p>
            </div>
            <div class="brief">
              <p>{{ data.owner.name }}是超讚房東</p>
              <span
              >超讚房東是一批經驗豐富、深獲房客好評的房東，全心為房客提供超棒的入住體驗。</span
              >
            </div>
            <a
                class="contact"
                data-bs-toggle="modal"
                data-bs-target="#myModal"
                @click.prevent="connectLandlord"
            >聯絡房東</a
            >
            <div class="security">
              <span
              >為了確保您的付款安全，切勿透過Airbnb網站或應用程式以外的方式進行匯款或聯絡。</span
              >
              <div class="icon">
                <img src="../assets/image/Room/icon/security.svg"/>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="rule">
        <h2 v-if="fullWidth > 768">注意事項</h2>
        <div class="rule-section">
          <a
              data-bs-toggle="modal"
              data-bs-target="#myModal"
              @click="isRuleShow = true"
              class="regulation main"
          >
            <div class="txt">
              <h2>《房屋守則》</h2>
              <span
              >入住時間 : 下午{{
                  data.houseRule.checkinTime
                }}</span
              >
              <HouseRule
                  v-if="fullWidth > 768"
                  :detail="data.houseRule"
              ></HouseRule>
            </div>
            <div class="arrow">></div>
          </a>
          <a
              data-bs-toggle="modal"
              data-bs-target="#myModal"
              @click="isHealthyShow = true"
              class="healthy main"
          >
            <div class="txt">
              <h2>健康與安全</h2>
              <span>運用Airbnb社交距離指南和其他防疫指南</span>
              <Healthy
                  v-if="fullWidth > 768"
                  :detail="data.houseRule"
              ></Healthy>
            </div>
            <div class="arrow">></div>
          </a>
          <a
              data-bs-toggle="modal"
              data-bs-target="#myModal"
              @click="isDatePickerShow = true"
              class="regulation main"
          >
            <div class="txt">
              <h2>退訂政策</h2>
              <span>新增旅程日期，即可查看此住宿的退訂詳情。</span>
              <Cancel
                  v-if="
                  fullWidth > 768 && Object.keys($store.state.date).length !== 0
                " :detail="data.cancelPolicy" :setting="setting"
              ></Cancel>
            </div>
            <div class="arrow">></div>
          </a>
        </div>
      </div>
      <div
          class="modal fade"
          tabindex="-1"
          id="myModal"
          data-bs-backdrop="static"
          data-bs-keyboard="false"
      >
        <div
            class="
            modal-dialog
            modal-lg
            modal-dialog-scrollable
            modal-dialog-centered
            modal-fullscreen-md-down
          "
        >
          <div class="modal-content">
            <button
                type="button"
                class="btn"
                data-bs-dismiss="modal"
                aria-label="Close"
                @click="invisible"
            >
              <img src="../assets/image/Room/icon/back.svg"/>
            </button>
            <div class="modal-body">
              <Description
                  v-if="isDescShow"
                  :detail="data.description"
              ></Description>
              <Facility
                  v-if="isFacilityShow"
                  :detail="data.facility"
                  :facilitySetting="setting"
              ></Facility>
              <Connect
                  v-if="isConnectShow"
                  :detail="data.owner"
                  :rule="data.houseRule"
              ></Connect>
              <HouseRule v-if="isRuleShow" :detail="data.houseRule"></HouseRule>
              <Healthy v-if="isHealthyShow" :detail="data.houseRule"></Healthy>
              <keep-alive>
                <Date v-if="isDateShow"></Date>
              </keep-alive>
              <People v-if="isPeopleShow"></People>
              <AllPicture
                  v-if="isPicShow && fullWidth < 768"
                  :detail="data.pictures"
              ></AllPicture>
              <keep-alive>
                <DatePicker
                    v-if="
                    isDatePickerShow &&
                    Object.keys($store.state.date).length === 0
                  "
                ></DatePicker>
              </keep-alive>
              <Cancel
                  v-if="
                  isDatePickerShow &&
                  Object.keys($store.state.date).length !== 0
                " :detail="data.cancelPolicy" :setting="setting"
              ></Cancel>
              <CommentModal v-if="isCommentShow" :comment="data.comments" :rank="data.rank"></CommentModal>
            </div>
            <div
                class="modal-footer d-flex flex-row justify-content-between"
                v-if="isConnectShow"
            >
              <p>有其他疑問嗎？</p>
              <button type="button" class="btn btn-primary btn-dark" @click.prevent="createMessage">
                傳訊息給房東
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import Picture from "../components/Room/Picture";
import Share from "../components/Room/Share";
import Description from "../components/Room/Decsription";
import Facility from "../components/Room/Facility";
import Date from "../components/Room/Date";
import Connect from "../components/Room/Connect";
import HouseRule from "../components/Room/HouseRule";
import Healthy from "../components/Room/Healthy";
import Location from "../components/Room/Location";
import People from "../components/Room/People";
import AllPicture from "../components/Room/AllPicture";
import DatePicker from "../components/Room/DatePicker";
import Cancel from "../components/Room/Cancel";
import Comment from "../components/Room/Comment";
import CommentModal from "../components/Room/ModalComment";
import Bed from "../components/Room/RoomDatasWithPic";
import settingJson from "../components/Settings/setting";
// import {moment} from 'moment';

export default {
  data() {
    return {
      data: {},
      get: false,
      isDescShow: false,
      isFacilityShow: false,
      isConnectShow: false,
      isRuleShow: false,
      isHealthyShow: false,
      isDateShow: false,
      isPeopleShow: false,
      isPicShow: false,
      isDatePickerShow: false,
      isCommentShow: false,
      fullWidth: 0,
      setting: settingJson,
    };
  },
  methods: {
    connectLandlord() {
      if (this.$store.state.login.token == "") window.location.href = '/account/login';
      this.isConnectShow = true;
    },
    createMessage() {
      let messageContent = document.getElementById('messageContent').value;
      if (Object.keys(this.$store.state.date).length == 0 || messageContent == "") {
        this.$swal('請填入住宿日期與訊息內容');
        return;
      }
      let mes = {
        MemberOneId: this.data.owner.id,
        MemberTwoId: this.$store.state.login.memberId,
        Contents: [{
          SenderId: this.$store.state.login.memberId,
          ReceiverId: this.data.owner.id,
          Content: messageContent,
          Time: '2021-09-11T00:00:00'
        }],
        HouseId: this.data.id,
        StartDate: this.getDate(this.$store.state.date.start),
        EndDate: this.getDate(this.$store.state.date.end),
        MemberOneStatus: 1,
        MemberTwoStatus: 0
      }
      this.useAxios(mes);
    },
    useAxios(mes) {
      let vm = this;
      axios.post(`/api/messages/${this.$store.state.login.memberId}/create`, mes, {
        headers: {
          "Access-Control-Allow-Origin": "*",
        }
      }).then(function () {
        document.getElementById('messageContent').value = "";
        vm.$swal('訊息傳送成功');
      }).catch(err => {
        console.log(err)
      })
    },
    getDate(x) {
      let year = x.slice(0, 4)
      let month = x.slice(5, 7)
      let day = x.slice(8, 10)
      return `${year}-${month}-${day}T00:00:00`;
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
    checkFacilityItem(item) {
      let temp = this.setting.facilities.filter(x => x.mapping == item)
      if (temp.length == 0) return false
      else return true
    },
    getFacilityIcon(item) {
      let icon = this.setting.facilities.filter(x => x.mapping == item)
      if (icon.length != 0 && icon[0].img != "") {
        return icon[0].img;
      } else {
        return require("@/assets/pic/FacilityIcons/HairDryer.svg");
      }
    },
    getFacilityName(item) {
      let icon = this.setting.facilities.filter(x => x.mapping == item)
      if (icon.length != 0) {
        return icon[0].chinese;
      }
    },
    //Axios
    getList() {
      axios
          .get(`/api/houses/${this.$route.params.houseId}`, {
            headers: {
              "Access-Control-Allow-Origin": "*",
            },
          })
          .then((res) => {
            this.data = res.data;
            console.log(res.data);
            this.getSpace();
            this.getRank();
            this.getHonor();
            this.getComment();
            this.getPortrait();
            this.getPicture();
            this.getTotalComments();
            this.getPrice();

            if (Object.keys(this.$store.state.room).length === 0) this.$store.state.room = this.data;
            else this.data = this.$store.state.room;
            this.get = true;
          });
    },
    //Todo-先給隨機Space資料
    getSpace() {
      if (this.data.space.bedroom == 0) this.data.space.bedroom = this.getRandomNumber(1, 6);
      if (this.data.space.bed == 0) this.data.space.bed = this.data.space.bedroom * 2;
      if (this.data.space.bathroom == 0) this.data.space.bathroom = this.getRandomNumber(1, 6);
      //Todo-先給隨機Bedroom資料
      if (this.data.bedroomDetail.length == 0) {
        let list = [];
        for (let i = 0; i < this.data.space.bedroom; i++) {
          let bed = ["Single", "Double"];
          let obj = {
            bedType: bed[this.getRandomNumber(0, 1)],
            bedCount: 2
          }
          list.push(obj);
        }
        this.data.bedroomDetail = list;
      }
    },
    //Todo-先給隨機Rank資料
    getRank() {
      if (this.data.rank.star.toFixed(2) !== 0) return;
      Object.keys(this.data.rank).forEach((x) => {
        if (x == "star") {
          this.data.rank[x] = 0
          return
        }
        let num = Math.random() * 5
        this.data.rank[x] = Number(num).toFixed(1);
      });
      let total = 0;
      Object.keys(this.data.rank).forEach(item => {
        total += Number(this.data.rank[item])
      })
      this.data.rank["star"] = (total / 6).toFixed(1)
    },
    //Todo-先給隨機Honor資料
    getHonor() {
      if (this.data.honor.length !== 0) return;
      this.getRandomList(0, this.setting.honor.length - 1, 4).forEach(x => {
        if (this.setting.honor[x].chinese.includes('資深房東')) {
          this.setting.honor[x].description = `${this.data.owner.name}在其他房源獲得了許多則評價。`
        }
        this.data.honor.push(this.setting.honor[x]);
      })
    },
    //Todo-先給隨機Portrait資料
    getPortrait() {
      if (this.data.owner.cover !== null) return;
      let num = this.getRandomList(0, this.setting.portraits.length - 1, 1)[0];
      this.data.owner.cover = this.setting.portraits[num];
    },
    //Todo-先給隨機Comment資料
    getComment() {
      if (this.data.comments.length !== 0) return;
      this.getRandomList(1, 30, this.getRandomNumber(1, 30)).forEach(x => {
        let num = this.getRandomList(0, this.setting.portraits.length - 1, 1)[0];
        let obj = {
          "authorId": x,
          "name": `阿明${x}`,
          "date": `2021-09-${x.toString().padStart(2, '0')}`,
          "content": "非常好的一次住宿體驗,回覆消息也都很及時｡",
          "portrait": `${this.setting.portraits[num]}`
        }
        this.data.comments.push(obj);
      })
    },
    //Todo-先給隨機Picture資料
    getPicture() {
      if (this.data.pictures.length !== 0) return;
      else if (this.$store.state.roomPicture.length !== 0) {
        this.data.pictures = this.$store.state.roomPicture
      } else {
        this.getRandomList(0, this.setting.pictures.length - 1, this.getRandomNumber(5, this.setting.pictures.length - 1)).forEach(x => {
          this.data.pictures.push(this.setting.pictures[x]);
        })
      }
    },
    //Todo-先給隨機TotalComments資料
    getTotalComments() {
      if (this.data.owner.totalComments !== 0) return;
      this.data.owner.totalComments = this.getRandomNumber(100, 1000)
    },
    //Todo-先給隨機Price資料
    getPrice() {
      if (this.data.price.fee.cleanFee !== 0) return;
      Object.keys(this.data.price.fee).forEach(x => {
        this.data.price.fee[x] = Math.round(this.data.price.origin * 0.1 + this.getRandomNumber(1, this.data.price.origin / 5));
      });
    },
    invisible() {
      this.isDescShow = false;
      this.isFacilityShow = false;
      this.isConnectShow = false;
      this.isRuleShow = false;
      this.isHealthyShow = false;
      this.isDateShow = false;
      this.isPeopleShow = false;
      this.isPicShow = false;
      this.isDatePickerShow = false;
      this.isCommentShow = false;
    },
    CommentShow(val) {
      this.isCommentShow = val;
    },
    goSubscribe() {
      if (this.$store.state.login.token == "") window.location.href = '/account/login';
      if (this.$store.getters.TotalCustomer == 0) {
        this.$swal('請填入房客人數');
        return
      }
      this.$router.push({
        path: `/subscribe/${this.data.id}`,
      });
    }
  },
  watch: {
    fullWidth(val) {
      this.fullWidth = val;
    },
  },
  mounted() {
    this.getList();
    const vm = this;
    this.fullWidth = document.body.clientWidth;
    window.addEventListener("resize", function () {
      vm.fullWidth = document.body.clientWidth;
    });
  },
  components: {
    Picture,
    Share,
    Description,
    Facility,
    Date,
    Connect,
    HouseRule,
    Healthy,
    Location,
    People,
    AllPicture,
    DatePicker,
    Cancel,
    Comment,
    CommentModal,
    Bed,
  },
};
</script>

<style lang="scss" scoped>
@import "../assets/css/reset.css";

.top {
  position: relative;
  text-align: left;
  color: #000;

  a {
    cursor: pointer;
  }

  .gap {
    margin: 0 1.5rem;
  }

  .mix-detail {
    border-bottom: 1px solid rgb(209, 206, 206);

    h1 {
      font-size: 1.5rem;
      font-weight: 700;
      margin: 1rem 0;
      line-height: 2rem;
      word-break: break-all;
    }

    .remix {
      font-size: 0.9rem;
      font-weight: 700;
      padding-bottom: 1.5rem;

      i {
        color: #ff385c;
      }

      .num {
        margin: 0 0.2rem;
        color: #222222;
      }

      .dot {
        margin: 0 0.5rem;
      }

      a {
        color: #717171;
      }
    }
  }

  .landlord-brief {
    border-bottom: 1px solid rgb(209, 206, 206);

    .house {
      display: flex;
      justify-content: space-between;
      align-items: center;
      margin: 1rem 0;

      .txt {
        font-weight: 700;

        p {
          margin: 0.6rem 0;
        }

        h2 {
          font-size: 1.5rem;
          font-weight: 700;
        }
      }

      .img {
        display: flex;

        img {
          margin: auto;
          border-radius: 50%;
        }
      }
    }

    .detail {
      padding-bottom: 1.5rem;
    }
  }

  .honor {
    border-bottom: 1px solid rgb(209, 206, 206);

    li {
      display: flex;
      margin: 2rem 0;
      align-items: center;

      i {
        font-size: 1.5rem;
        align-self: start;
      }

      .detail {
        margin-left: 1rem;

        p {
          font-size: 1.1rem;
          font-weight: 700;
        }

        span {
          display: block;
          margin-top: .5rem;
          color: #717171;
          font-size: 0.9rem;
        }
      }
    }
  }

  .description {
    padding: 1rem 0;
    border-bottom: 1px solid rgb(209, 206, 206);

    a {
      text-decoration: underline;
      display: block;
      margin: 1rem 0;
      font-weight: 900;
      color: #222222;

      &:hover {
        color: #000;
      }
    }
  }

  .facility {
    padding: 1.5rem 0;
    border-bottom: 1px solid rgb(209, 206, 206);

    .hide {
      height: 18rem;
      overflow: hidden;
      margin: 1rem 0;
    }

    h2 {
      font-size: 1.5rem;
      font-weight: 900;
    }

    li {
      display: flex;
      align-items: center;
      margin: 1rem 0;

      span {
        display: block;
        margin-left: 0.7rem;
      }
    }

    a {
      display: block;
      text-decoration: none;
      padding: 1rem 2rem;
      color: #222222;
      text-align: center;
      border: 1px solid #222222;
      border-radius: 8px;
      font-weight: 700;
      transition: 0.3s;

      &:hover {
        background-color: #ddd9d9;
      }
    }
  }

  .price {
    position: fixed;
    left: 0;
    bottom: 0;
    background-color: #ffffff;
    display: flex;
    justify-content: space-between;
    border-top: 1px solid rgb(231, 231, 231);
    width: 100%;
    padding: 0.8rem 1.5rem;
    z-index: 100;

    .mix {
      i {
        color: #ff385c;
      }

      a {
        color: #717171;
      }

      p {
        font-size: 1.2rem;
        font-weight: 700;
        margin: 0.5rem 0;
      }
    }

    button {
      background-color: rgb(215, 4, 102);
      color: #fff;
      font-weight: 700;
      padding: 0 1.8rem;
      border: none;
      border-radius: 8px;

      &:hover {
        background-color: rgb(197, 4, 94);
      }
    }

    .hide-price {
      .price-show {
        display: flex;
        justify-content: space-between;
        margin: 1rem 0;
      }

      .price-total {
        display: flex;
        justify-content: space-between;
        padding: 1rem 0;
        border-top: 1px solid #717171;
        font-weight: 700;
        font-size: 1.2rem;
      }
    }
  }

  .landlord {
    margin-top: 1.5rem;
    border-bottom: 1px solid rgb(209, 206, 206);

    .detail {
      display: flex;
      justify-content: space-between;

      .txt {
        font-weight: 700;

        p {
          margin: 0.6rem 0;
          font-size: 1.5rem;
        }

        span {
          color: #717171;
          font-size: 0.9rem;
        }
      }

      .img {
        display: flex;

        img {
          margin: auto;
          border-radius: 50%;
        }
      }
    }

    .mix {
      margin: 2rem 0;

      p {
        margin: 1.3rem 0;
        color: #222222;

        i {
          color: #ff385c;
          margin-right: 1rem;
        }
      }
    }

    .brief {
      p {
        font-weight: 700;
        font-size: 1.2rem;
      }

      span {
        display: block;
        margin: 1rem 0;
        line-height: 1.6rem;
      }
    }

    .contact {
      display: block;
      text-decoration: none;
      padding: 1rem 2rem;
      color: #222222;
      text-align: center;
      border: 1px solid #222222;
      border-radius: 8px;
      font-weight: 700;
      transition: 0.3s;

      &:hover {
        background-color: #ddd9d9;
      }
    }

    .security {
      display: flex;
      margin: 1rem 0;
      align-items: center;

      span {
        font-size: 0.8rem;
        line-height: 1.2rem;
      }

      .icon {
        padding: 0.5rem;

        img {
          width: 1.5rem;
        }
      }
    }
  }

  .rule {
    h2 {
      font-size: 1.5rem;
      font-weight: 700;
    }

    .main {
      display: flex;
      align-items: center;
      justify-content: space-between;
      margin: 1.5rem 0;
      border-bottom: 1px solid rgb(209, 206, 206);
      text-decoration: none;
      color: #222222;

      .txt {
        h2 {
          font-size: 1.5rem;
          font-weight: 900;
        }

        span {
          display: block;
          color: #717171;
          margin: 1rem 0;
          font-size: 0.9rem;
        }
      }

      .arrow {
        font-size: 1.5rem;
      }
    }

    .report {
      a {
        margin-left: 1rem;
        color: #222222;
      }
    }
  }

  .modal {
    .btn {
      width: 10%;
      padding: 1rem 2rem;

      img {
        width: 1.3rem;
      }
    }

    .modal-footer {
      button {
        width: 50%;
        font-weight: 700;
        border-radius: 8px;
        font-size: 1.1rem;
      }
    }
  }
}

.dateBottom {
  border-bottom: 1px solid rgb(209, 206, 206);
}

.price-sticky {
  position: relative;
}

.nav {
  width: 100vw;
  height: 5rem;
  background-color: #fff;
  border: 1px solid #000;
  position: fixed;
  z-index: 100;
  top: 0;
  left: 0;
  opacity: 0;
}

.nav.show {
  opacity: 100;
}

@media screen and (min-width: 768px) {
  .top {
    margin: 0 11rem;
    padding-top: 7rem;

    .bed,
    .comments,
    .footer {
      .txt {
        height: 20rem;
        line-height: 20rem;
      }
    }

    .landlord-section,
    .sticky-section {
      position: relative;
      border-bottom: 1px solid rgb(209, 206, 206);
      margin: 0 0.1rem;
    }

    .mix-detail {
      border: none;

      .mix-md {
        justify-content: space-between;
        height: 3.5rem;
      }
    }

    .landlord-brief {
      .detail {
        margin-top: -1rem;
      }
    }

    .facility {
      a {
        width: 38%;
      }
    }

    .landlord {
      border: none;
    }

    .rule {
      margin-top: 1.5em;

      .rule-section {
        display: flex;
        justify-content: space-between;
        align-items: flex-start;

        .main {
          width: 20rem;
          border: none;
          pointer-events: none;

          .txt {
            h2 {
              font-size: 1rem;
            }
          }

          .arrow,
          span {
            display: none;
          }
        }
      }
    }

    .price {
      position: sticky;
      bottom: unset;
      top: 10rem;
      z-index: 5;
      border: 1px solid #cacaca;
      box-shadow: 3px 3px 10px rgb(179, 179, 179);
      border-radius: 18px;
      flex-direction: column;
      width: 90%;
      margin: auto;
      margin-top: 2rem;

      .mix {
        display: flex;
        justify-content: space-between;
        align-items: center;

        p {
          font-size: 1.5rem;
        }
      }

      button {
        height: 3rem;
        margin-bottom: 0.8rem;
      }

      .choice {
        border: 1px solid #717171;
        border-radius: 8px;
        margin: 1rem 0;
        cursor: pointer;

        .pick-date {
          display: flex;
          justify-content: space-between;
          border-bottom: 1px solid #717171;

          .in-date {
            border-right: 1px solid #717171;
          }
        }

        .search-div {
          width: 50%;
          padding: 0.5rem 0;
          margin-left: 0.5rem;

          span {
            font-weight: 700;
          }

          .placeholder {
            color: #717171;
            margin: 0.1rem 0;
          }
        }

        .people {
          width: 100%;
        }
      }
    }
  }
  .dateBottom {
    border-bottom: none;
  }
}
</style>
