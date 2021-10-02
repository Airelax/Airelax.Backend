<template>
  <!-- 手機板 768px以下 不含768px-->
  <div
    class="offcanvas offcanvas-bottom d-md-none"
    tabindex="-1"
    id="wish"
    aria-labelledby="wishTitle"
  >
    <div class="offcanvas-header">
      <button
        type="button"
        class="btn-close text-reset"
        data-bs-dismiss="offcanvas"
        aria-label="Close"
      ></button>
      <p class="offcanvas-title" id="wishTitle">你的心願單</p>
    </div>
    <div class="offcanvas-body small">
      <div
        class="row"
        data-bs-target="#createWish"
        data-bs-toggle="offcanvas"
        aria-controls="offcanvasBottom"
      >
        <div class="col-3">
          <img
            src="https://a0.muscache.com/im/pictures/2cf775f5-3b30-4806-8572-977a74b6834e.jpg"
            alt="+"
          />
        </div>
        <div class="col-9">建立新的心願單</div>
      </div>

      <div
        class="row"
        data-bs-dismiss="offcanvas"
        v-for="item in wishLists"
        :key="item"
        @click="send(item.id)"
      >
        <div class="col-3">
          <img
            :src="'https://picsum.photos/600/400/?random=100'"
            :alt="item.name"
          />
          <!---:src="item.cover"--->
        </div>
        <div class="col-9">{{ item.name }}</div>
      </div>
    </div>
  </div>
  <!-- 768px以上 含768px -->
  <!-- Modal -->
  <div
    class="modal fade"
    id="mdWish"
    tabindex="-1"
    aria-labelledby="mdWishLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <button
            type="button"
            class="btn-close"
            id="close"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
          <p class="modal-title" id="mdWishLabel">你的心願單</p>
        </div>
        <div class="modal-body">
          <div
            class="row toCr"
            data-bs-toggle="modal"
            data-bs-target="#mdCreateWish"
            data-bs-dismiss="modal"
          >
            <div class="col-3">
              <img
                src="https://a0.muscache.com/im/pictures/2cf775f5-3b30-4806-8572-977a74b6834e.jpg"
                alt="+"
              />
            </div>
            <div class="col-9">建立新的心願單</div>
          </div>
          <div
            class="row"
            data-bs-dismiss="modal"
            v-for="item in wishLists"
            :key="item"
            @click="send(item.id)"
          >
            <div class="col-3">
              <img
                :src="'https://picsum.photos/600/400/?random=100'"
                :alt="item.name"
              />
              <!---:src="item.cover"--->
            </div>
            <div class="col-9">{{ item.name }}</div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  methods: {
    send: function (wishId) {
      const dataUrl = `/api/wishLists/Houses`;
      const vm = this;
      axios({
        method: "Put",
        url: dataUrl,
        headers: {
          "Content-Type": "application/json",
        },
        data: {
          HouseId: this.$store.state.selectedWishHouseId,
          WishId: wishId,
        },
      })
        .then(function () {
          vm.$emit(
            "onWishListUpdated",
            wishId,
            vm.$store.state.selectedWishHouseId,
          );
        })
        .catch((err) => console.log(err));
    },
  },
  props: {
    wishLists: { type: Array },
  },
};
</script>

<style lang="scss" scoped>
.btn-close {
  color: #000;
  opacity: 1;
  font-size: 12px;
}
.btn-close:hover {
  background-color: #efefef80;
  border-radius: 50%;
}
.offcanvas {
  border-top-left-radius: 12px;
  border-top-right-radius: 12px;
  height: auto;
  .offcanvas-header {
    border-bottom: 0.5px solid #ededed;
    padding: 20px 30px;
    .offcanvas-title {
      margin: auto;
      font-size: 16px;
      font-weight: 500;
    }
  }
  .offcanvas-body {
    .row {
      margin-top: 10px;
      .col-3 {
        img {
          width: 70px;
          height: 70px;
          border-radius: 10px;
        }
      }
      .col-9 {
        font-size: 16px;
        font-weight: 400;
        text-align: start;
        margin-top: auto;
        margin-bottom: auto;
      }
    }
  }
}
.modal {
  .modal-dialog {
    .modal-content {
      border-radius: 10px;
      .modal-header {
        margin: auto;
        border: none;
        .btn-close {
          position: relative;
          right: 170px;
        }
        .modal-title {
          color: #000;
          font-size: 16px;
          font-weight: 500;
        }
      }
      .modal-body {
        border-top: 0.5px solid #ededed;
        .row {
          margin-top: 10px;
          .col-3 {
            img {
              width: 70px;
              height: 70px;
              border-radius: 10px;
            }
          }
          .col-9 {
            font-size: 16px;
            font-weight: 400;
            text-align: start;
            margin-top: auto;
            margin-bottom: auto;
          }
        }
      }
    }
  }
}
</style>