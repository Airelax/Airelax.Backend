<template>
  <div class="row requiredInfo">
    <h3>旅程必填資訊</h3>
    <div class="col-9">
      <p>傳訊息給房東</p>
      <p>告訴房東您旅行的目的和入住時間。</p>
    </div>
    <div class="col-3">
      <div
          class="btn"
          type="button"
          data-bs-toggle="offcanvas"
          data-bs-target="#message"
          aria-controls="message"
          v-if="fullWidth < 768"
          @click.prevent="connectLandlord"
      >
        新增
      </div>
      <div
          class="btn"
          type="button"
          data-bs-toggle="modal"
          data-bs-target="#messageModal"
          v-if="fullWidth >= 768"
          @click.prevent="connectLandlord"
      >
        新增
      </div>
    </div>
  </div>
  <!-- <768 -->
  <div
      class="offcanvas offcanvas-bottom messageOffcanvas"
      tabindex="-1"
      id="message"
      aria-labelledby="messageLabel"
      v-if="fullWidth < 768"
  >
    <div class="offcanvas-header">
      <button
          type="button"
          class="btn-close text-reset"
          data-bs-dismiss="offcanvas"
          aria-label="Close"
      ></button>
      <h5 class="offcanvas-title" id="messageLabel">傳訊息給房東</h5>
    </div>
    <div class="offcanvas-body small">
      <div class="row">
        <p>傳訊息給房東</p>
        <p>告訴房東您旅行的目的和入住時間。</p>
      </div>
      <div class="row">
        <div class="col-1">
          <img :src="data.owner.cover"/>
        </div>
        <div class="col-11">
          <p class="name">{{ data.owner.name }}</p>
          <p class="time">加入時間:{{ data.owner.registerTime.split('T')[0] }}</p>
        </div>
      </div>
      <textarea
          class="form-control"
          v-model="messageContent"
      ></textarea>
    </div>
    <div class="offcanvas-footer">
      <button class="btn btn-dark" @click="createMessage">儲存</button>
    </div>
  </div>
  <!-- >=768 -->
  <div
      class="modal fade messageModal"
      id="messageModal"
      tabindex="-1"
      aria-labelledby="messageModalLabel"
      aria-hidden="true"
      v-if="fullWidth >= 768"
  >
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">傳訊息給房東</h5>

          <div
              type="button"
              class="btn-close"
              data-bs-dismiss="modal"
              aria-label="Close"
          ></div>
        </div>
        <div class="modal-body">
          <div class="row">
            <p>傳訊息給房東</p>
            <p>告訴房東您旅行的目的和入住時間。</p>
          </div>
          <div class="row">
            <div class="col-1">
              <img :src="data.owner.cover"/>
            </div>
            <div class="col-11">
              <p class="name">{{ data.owner.name }}</p>
              <p class="time">加入時間:{{ data.owner.registerTime.split('T')[0] }}</p>
            </div>
          </div>
          <textarea
              class="form-control"
              v-model="messageContent"
          ></textarea>
        </div>
        <div class="modal-footer">
          <button class="btn btn-dark" @click="createMessage">儲存</button>
        </div>
      </div>
    </div>
  </div>
</template>
<style lang="scss" scoped>
//#region 共用
.requiredInfo > .col-9,
.offcanvas-body > .row {
  p:nth-of-type(1) {
    font-weight: 500;
  }

  p:nth-of-type(2) {
    color: #717171;
  }
}

//#endregion
.requiredInfo {
  .col-9 {
    p {
      font-size: 16px;
      padding: 10px 0;
    }
  }

  .col-3 {
    text-align: end;
    padding-right: 0;

    .btn {
      padding: 5 20px;
      border: 1px solid #717171;
      font-weight: 500;
      border-radius: 10px;
    }
  }
}

.messageOffcanvas {
  .offcanvas-body {
    .row:nth-of-type(1) {
      margin-bottom: 10px;

      p {
        font-size: 14px;
        padding: 5px;
      }
    }

    .row:nth-of-type(2) {
      font-size: 15px;
      padding: 10px 0;

      .col-1 {
        img {
          width: 40px;
          height: 40px;
          border-radius: 50%;
        }
      }

      .col-11 {
        padding-left: 20px;

        .name {
          font-weight: 500;
        }

        .time {
          padding-top: 5px;
        }
      }
    }

    textarea {
      height: 200px;
      resize: none;
      border-radius: 10px;
    }
  }

  .offcanvas-footer {
    padding: 25px;

    .btn {
      width: 100%;
      text-align: center;
      font-size: 18px;
      padding: 10px 0;
      border-radius: 10px;
    }
  }
}

.messageModal {
  .modal-body {
    .row:nth-of-type(1) {
      margin-bottom: 10px;

      p {
        font-size: 14px;
        padding: 5px;
      }
    }

    .row:nth-of-type(2) {
      font-size: 15px;
      padding: 10px 0;

      .col-1 {
        img {
          width: 40px;
          height: 40px;
          border-radius: 50%;
        }
      }

      .col-11 {
        padding-left: 20px;

        .name {
          font-weight: 500;
        }

        .time {
          padding-top: 5px;
        }
      }
    }

    textarea {
      height: 200px;
      resize: none;
      border-radius: 10px;
    }
  }

  .modal-footer {
    padding: 25px;

    .btn {
      width: 100%;
      text-align: center;
      font-size: 18px;
      padding: 10px 0;
      border-radius: 10px;
    }
  }
}
</style>
<script>
import axios from "axios";

export default {
  props: {
    fullWidth: {
      type: Number,
    }
  },
  inject: ["data"],
  data() {
    return {
      messageContent: "",
    }
  },
  methods: {
    createMessage() {
      let mes = {
        MemberOneId: this.data.owner.id,
        MemberTwoId: this.$store.state.login.memberId,
        Contents: [{
          SenderId: this.$store.state.login.memberId,
          ReceiverId: this.data.owner.id,
          Content: this.messageContent,
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
      if (vm.messageContent == "") {
        vm.$swal('請填入訊息內容');
        return;
      }
      axios.post(`/api/messages/${vm.data.memberId}/create`, mes, {
        headers: {
          "Access-Control-Allow-Origin": "*",
        }
      }).then(function () {
        vm.messageContent = "";
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
    }
  }
};
</script>