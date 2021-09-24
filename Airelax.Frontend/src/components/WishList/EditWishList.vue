<template>
  <!-- 手機板 768px以下 不含768px-->
  <div
    class="offcanvas offcanvas-bottom d-md-none"
    tabindex="-1"
    id="editWish"
    aria-labelledby="editWishTitle"
  >
    <div class="offcanvas-header">
      <button
        type="button"
        class="btn-close"
        data-bs-dismiss="offcanvas"
        aria-label="Close"
      ></button>
      <p class="offcanvas-title" id="editWishTitle">編輯</p>
    </div>
    <div class="offcanvas-body small">
      <div class="row">
        <form class="form-floating">
          <input
            type="text"
            class="form-control"
            id="floatingInputValue"
            maxlength="50"
            v-model="title"
          />
          <label for="floatingInputValue">心願單名稱</label>
        </form>
        <div class="maxLength"><label for="">最多50字元</label></div>
      </div>
      <div class="delete">
        <a
          href="#"
          data-bs-target="#deleteWish"
          data-bs-toggle="offcanvas"
          aria-controls="offcanvasBottom"
          >刪除此心願單</a
        >
      </div>
    </div>
    <div class="offcanvas-footer">
      <div data-bs-dismiss="offcanvas" class="cancelBtn btn" @click="cancel">
        取消
      </div>
      <div data-bs-dismiss="offcanvas" class="saveBtn btn" @click="send">
        儲存
      </div>
    </div>
  </div>
  <!-- 768px以上 含768px -->
  <!-- Modal -->
  <div
    class="modal fade"
    id="mdEditWish"
    tabindex="-1"
    aria-labelledby="mdEditWishLabel"
  >
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
          <p class="modal-title" id="mdEditWishLabel">編輯</p>
        </div>
        <div class="modal-body">
          <div class="row">
            <form class="form-floating">
              <input
                type="text"
                class="form-control"
                id="floatingInputValue"
                maxlength="50"
                v-model="title"
              />
              <label for="floatingInputValue">心願單名稱</label>
            </form>
            <div class="maxLength"><label for="">最多50字元</label></div>
          </div>
          <div class="delete">
            <a
              href="#"
              data-bs-target="#mdDelWish"
              data-bs-toggle="modal"
              data-bs-dismiss="modal"
              >刪除此心願單
            </a>
          </div>
        </div>
        <div class="modal-footer">
          <div data-bs-dismiss="modal" class="cancelBtn btn" @click="cancel">
            取消
          </div>
          <div data-bs-dismiss="modal" class="saveBtn btn" @click="send">
            儲存
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      title: this.$store.state.wishListData.wishName,
    };
  },
  methods: {
    cancel: function () {
      this.title = this.$store.state.wishListData.wishName;
    },
    send: function () {
      const dataUrl = `/api/wishLists/`;
      axios({
        method: "Put",
        url: dataUrl,
        headers: {
          "Content-Type": "application/json",
        },
        data: {
          WishName: this.title,
          WishId: this.$store.state.wishListData.id,
        },
      })
        .then(() => (this.$store.state.wishListData.wishName = this.title))
        .catch((err) => console.log(err));
    },
  },
};
</script>

<style scoped>
.modal.fade,
.offcanvas.offcanvas-bottom {
  color: #222;
}
.modal-content {
  border-radius: 16px;
}
.modal-header,
.offcanvas-header {
  padding: 16px 24px;
  height: 64px;
}
.offcanvas-header {
  border-bottom: 1px solid #ddd;
}
.modal-header .btn-close,
.offcanvas-header .btn-close {
  margin: -0.625rem auto -0.625rem -0.625rem;
}
.btn-close {
  font-size: 12px;
  opacity: 0.8;
  border-radius: 50%;
  padding: 10px;
}
.btn-close:hover {
  background-color: #eee;
}
.modal-title,
.offcanvas-title {
  font-weight: 800;
  margin-right: auto;
  padding-right: 11px;
}
.modal-body,
.offcanvas-body {
  padding: 32px;
}
.form-control {
  color: #222;
  border: 1px solid #979797;
  border-radius: 10px;
}
.form-floating label {
  font-size: 15px;
  font-weight: 800;
}
.maxLength {
  margin: 8px 0 32px;
}
.maxLength label {
  font-size: 12px;
  color: #717171;
}
.maxLength,
.delete {
  text-align: start;
}
.delete {
  padding-top: 29px;
  border-top: 1px solid #ddd;
}
.delete a {
  font-size: 14px;
  color: #b32505;
  padding: 15px 10px;
  margin-left: -10px;
}
.modal-footer,
.offcanvas-footer {
  padding: 16px 24px;
  justify-content: space-between;
  align-items: center;
}
.offcanvas-footer {
  display: flex;
  border-top: 1px solid #ddd;
}
.cancelBtn.btn,
.saveBtn.btn {
  font-weight: 800;
}
.cancelBtn.btn {
  margin: 0 -10px;
  padding: 10px;
  text-decoration: underline;
  color: #222;
  border-radius: 8px;
}
.cancelBtn.btn:hover {
  color: rgba(34, 34, 34, 0.9);
  background-color: #eee;
}
.saveBtn.btn {
  margin: 0;
  padding: 14px 24px;
  color: #fff;
  background-color: #222;
  border-radius: 8px;
}
.saveBtn.btn:hover {
  background-color: rgba(34, 34, 34, 0.9);
}
.offcanvas-bottom {
  height: fit-content;
}
#editWish {
  border-top-left-radius: 16px;
  border-top-right-radius: 16px;
}
</style>