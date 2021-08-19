<template>
  <!-- 手機板 768px以下 不含768px-->
  <div
    class="offcanvas offcanvas-bottom d-md-none"
    tabindex="-1"
    id="createWish"
    aria-labelledby="wishTitle"
  >
    <div class="offcanvas-header">
      <button
        type="button"
        class="btn-close text-reset"
        data-bs-dismiss="offcanvas"
        aria-label="Close"
      ></button>
      <p class="offcanvas-title" id="wishTitle">為你的心願單取名</p>
    </div>
    <div class="offcanvas-body small">
      <form class="form-floating">
        <input
          type="email"
          class="form-control"
          id="floatingInputValue"
          value="逮爸"
        />
        <label for="floatingInputValue">心願單名稱</label>
      </form>
      <div class="maxLength"><label for="">最多50字元</label></div>
    </div>
    <div class="offcanvas-footer">
      <div class="btn">建立</div>
    </div>
  </div>
  <!-- 768px以上 含768px -->
  <!-- Modal -->
  <div
    class="modal fade"
    id="mdCreateWish"
    tabindex="-1"
    aria-labelledby="mdCreateWishLabel"
    aria-hidden="true"
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
          <p class="modal-title" id="mdCreateWishLabel">為你的心願單取名</p>
        </div>
        <div class="modal-body">
          <form class="form-floating">
            <input
              type="email"
              class="form-control"
              id="floatingInputValue"
              value="逮爸"
            />
            <label for="floatingInputValue">心願單名稱</label>
          </form>
          <div class="maxLength"><label for="">最多50字元</label></div>
        </div>
        <div class="footer">
          <div class="btn">建立</div>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
/*共用開頭 */
* {
  font-family: "Noto Sans TC", sans-serif;
  .form-floating {
    .form-control {
      border-radius: 10px;
    }
    .form-control:link {
      border: 1px solid #616161;
    }
    .form-control:focus {
      border: 2px solid #000;
    }
  }
  .maxLength {
    font-size: 12px;
    text-align: start;
    font-weight: 200;
    padding-left: 5px;
    padding-top: 5px;
    color: #5f5f5f;
  }
  .btn-close {
    color: #000;
    opacity: 1;
    border-radius: 50%;
    font-size: 12px;
  }
  .btn-close:hover {
    background-color: #efefef80;
  }
}
/*共用結尾 */
//768px以下offcanvas
.offcanvas {
  border-top-left-radius: 12px;
  border-top-right-radius: 12px;
  height: auto;
  .offcanvas-header {
    border-bottom: 0.5px solid #ededed;
    padding: 20px 30px;
    .offcanvas-title {
      color: #000;
      margin: auto;
      font-size: 16px;
      font-weight: 500;
    }
  }
  .offcanvas-body {
    padding: 20px 30px;
  }
  .offcanvas-footer {
    border-top: 0.5px solid #ededed;
    padding: 20px 30px;
    .btn {
      font-size: 16px;
      display: block;
      padding: 10px;
      background-color: #000;
      color: #fff;
      border-radius: 10px;
    }
  }
}
//768px以上modal
.modal {
  .modal-dialog {
    .modal-content {
      border-radius: 10px;
      .modal-header {
        margin: auto;
        border: none;
        .btn-close {
          position: relative;
          right: 155px;
        }
        .modal-title {
          color: #000;
          font-size: 16px;
          font-weight: 500;
        }
      }
      .modal-body {
        border-top: 0.5px solid #ededed;
      }
    }
    .footer {
      border-top: 0.5px solid #ededed;
      padding: 20px;
      .btn {
        font-size: 16px;
        display: block;
        padding: 10px;
        background-color: #000;
        color: #fff;
        border-radius: 10px;
      }
    }
  }
}
</style>