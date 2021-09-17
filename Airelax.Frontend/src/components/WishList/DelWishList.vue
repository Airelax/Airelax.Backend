<template>
  <!-- 手機板 768px以下 不含768px-->
  <div
    class="offcanvas offcanvas-bottom"
    tabindex="-1"
    id="deleteWish"
    aria-labelledby="deleteWishTitle"
  >
    <div class="offcanvas-header">
      <button
        type="button"
        class="btn-close text-reset"
        data-bs-dismiss="offcanvas"
        data-bs-target="#editWish"
        data-bs-toggle="offcanvas"
        aria-controls="offcanvasBottom"
        aria-label="Close"
      ></button>
      <p class="offcanvas-title" id="deleteWishTitle">刪除此心願單</p>
    </div>
    <div class="offcanvas-body small">
      <p>確定要刪除{{ $store.state.wishListData.wishName }}嗎?</p>
    </div>
    <div class="offcanvas-footer">
      <div
        class="cancelBtn btn"
        data-bs-dismiss="offcanvas"
        data-bs-target="#editWish"
        data-bs-toggle="offcanvas"
        aria-controls="offcanvasBottom"
      >
        取消
      </div>
      <div data-bs-dismiss="offcanvas" class="submitBtn btn">刪除</div>
    </div>
  </div>
  <!-- 768px以上 含768px -->
  <!-- Modal -->
  <div
    class="modal fade"
    id="mdDelWish"
    tabindex="-1"
    aria-labelledby="mdDelWishLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            data-bs-target="#mdEditWish"
            data-bs-toggle="modal"
            aria-label="Close"
          ></button>
          <p class="modal-title" id="mdDelWishLabel">刪除此心願單</p>
        </div>
        <div class="modal-body">
          <p>確定要刪除{{ $store.state.wishListData.wishName }}嗎?</p>
        </div>
        <div class="modal-footer">
          <div
            class="cancelBtn btn"
            data-bs-dismiss="modal"
            data-bs-target="#mdEditWish"
            data-bs-toggle="modal"
          >
            取消
          </div>
          <div data-bs-dismiss="offcanvas" class="submitBtn btn">刪除</div>
        </div>
      </div>
    </div>
  </div>
</template>

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
  margin: -0.5rem auto -0.5rem -0.5rem;
}
.btn-close {
  font-size: 12px;
  opacity: 0.8;
  border-radius: 50%;
}
.modal-title,
.offcanvas-title {
  font-weight: 800;
  margin-right: auto;
  padding-right: 10px;
}
.modal-body,
.offcanvas-body {
  padding: 32px;
}
.modal-body p,
.offcanvas-body p {
  font-size: 14px;
  margin: 0;
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
.submitBtn.btn {
  font-weight: 800;
}
.cancelBtn.btn {
  margin: 0 -10px;
  padding: 10px;
  text-decoration: underline;
  color: #222;
}
.submitBtn.btn {
  margin: 0;
  padding: 14px 24px;
  color: #fff;
  background-color: #222;
  border-radius: 8px;
}
.offcanvas-bottom {
  height: fit-content;
}
#deleteWish {
  border-top-left-radius: 16px;
  border-top-right-radius: 16px;
}
</style>