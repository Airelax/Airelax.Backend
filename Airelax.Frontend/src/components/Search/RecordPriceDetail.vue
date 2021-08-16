<template>
  <div
    class="offcanvas offcanvas-bottom d-md-none"
    tabindex="-1"
    id="recordPriceDetail"
    aria-labelledby="recordPriceDetailTitle"
  >
    <div class="offcanvas-header">
      <button
        type="button"
        class="btn-close text-reset"
        data-bs-dismiss="offcanvas"
        aria-label="Close"
      ></button>
      <p class="offcanvas-title" id="recordPriceDetailTitle">價格明細</p>
    </div>
    <div v-if="price" class="offcanvas-body small">
      <div class="calTotal">
        <p>
          ${{ convertToLocaleString(Number(price.sweetPrice)) }}x{{
            nightCount
          }}晚
        </p>
        <p>
          ${{ convertToLocaleString(Number(price.sweetPrice) * nightCount) }}
        </p>
      </div>
      <div class="fees">
        <div class="clean" v-if="price.Fee.CleanFee">
          <p>清潔費</p>
          <p>${{ convertToLocaleString(Number(price.Fee.CleanFee)) }}</p>
        </div>
        <div class="service" v-if="price.Fee.ServiceFee">
          <p>服務費</p>
          <p>${{ convertToLocaleString(Number(price.Fee.ServiceFee)) }}</p>
        </div>
        <div class="tax" v-if="price.Fee.taxFee">
          <p>稅額</p>
          <p>${{ convertToLocaleString(Number(price.Fee.taxFee)) }}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.offcanvas {
  border-top-left-radius: 12px;
  border-top-right-radius: 12px;
  height: auto;
  color: #000;
  .offcanvas-header {
    border-bottom: 0.5px solid #ededed;
    padding: 20px;
    .btn-close {
      opacity: 1;
      font-size: 12px;
    }
    .btn-close:hover {
      background-color: #efefef80;
      border-radius: 50%;
    }
    .offcanvas-title {
      margin: auto;
      font-size: 16px;
      font-weight: 500;
    }
  }
  .offcanvas-body {
    font-size: 15px;
    padding: 20px;
    .calTotal,
    .clean,
    .service,
    .tax {
      display: flex;
      flex-direction: row;
      justify-content: space-between;
      letter-spacing: 1px;
    }
  }
}
</style>

<script>
export default {
  props: {
    price: {
      type: Object,
    },
    nightCount: {
      type: Number,
    },
  },
  methods: {
    convertToLocaleString(price) {
      return price.toLocaleString();
    },
  },
};
</script>