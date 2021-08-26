<template>
  <div class="row payWay">
    <h3>付款方式</h3>
    <div
      class="col-12 btn"
      type="button"
      id="creditBtn"
      data-bs-toggle="offcanvas"
      data-bs-target="#credit"
      aria-controls="offcanvas"
      v-if="fullWidth < 768"
    >
      <img src="@/assets/image/Subscribe/creditCard.svg" alt="creditCard" />
      <p>信用卡或簽帳卡</p>
    </div>
    <div
      class="col-12 btn"
      type="button"
      id="creditBtn"
      data-bs-toggle="modal"
      data-bs-target="#creditModal"
      v-if="fullWidth >= 768"
    >
      <img src="@/assets/image/Subscribe/creditCard.svg" alt="creditCard" />
      <p>信用卡或簽帳卡</p>
    </div>

    <div class="col-12 btn" id="googlePay">
      <img src="@/assets/image/Subscribe/GooglePay.svg" alt="googlePay" />
      <p>GooglePay</p>
    </div>
  </div>

  <div
    class="offcanvas offcanvas-bottom creditOffcanvas"
    tabindex="-1"
    id="credit"
    aria-labelledby="creditLabel"
  >
    <div class="offcanvas-header">
      <button
        type="button"
        class="btn-close text-reset"
        data-bs-dismiss="offcanvas"
        aria-label="Close"
      ></button>
      <h5 class="offcanvas-title" id="creditLabel">新增信用卡詳情</h5>
    </div>
    <div class="offcanvas-body small">
      <CreditVisaForm></CreditVisaForm>
    </div>
    <div class="offcanvas-footer d-flex pe-4">
      <div class="btn btn-dark ms-auto" data-bs-dismiss="offcanvas">完成</div>
    </div>
  </div>

  <div
    class="modal fade creditModal"
    id="creditModal"
    tabindex="-1"
    aria-labelledby="creditModalLabel"
    aria-hidden="true"
    v-if="fullWidth >= 768"
  >
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">信用卡詳情</h5>

          <div
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></div>
        </div>
        <div class="modal-body">
          <CreditVisaForm></CreditVisaForm>
        </div>
        <div class="modal-footer">
          <div class="btn btn-dark" data-bs-dismiss="modal">儲存</div>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.payWay {
  .col-12 {
    padding: 10px;
    display: flex;
    align-items: center;
    img {
      width: 30px;
    }
    p {
      font-weight: 300;
      margin-left: 20px;
    }
  }
}
</style>

<script>
import CreditVisaForm from "../Subscribe/CreditVisaForm.vue";
export default {
  props: {
    fullWidth: {
      type: Number,
    },
  },
  components: {
    CreditVisaForm,
  },
};
</script>