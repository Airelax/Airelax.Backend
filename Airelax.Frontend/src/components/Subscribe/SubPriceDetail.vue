<template>
  <div class="SubPriceDetail">
    <h3>價格詳情</h3>
    <div class="row roomPrice">
      <div class="col-6">
        ${{ convertToLocaleString(room.Price.sweetPrice) }} x
        {{ Number(nightCount) }}晚
      </div>
      <div class="col-6 text-end">
        ${{
          convertToLocaleString(
            Number(room.Price.sweetPrice) * Number(nightCount)
          )
        }}
      </div>
    </div>
    <div class="row cleanFee" v-if="room.Price.Fee.CleanFee">
      <div class="col-6">清潔費</div>
      <div class="col-6 text-end">
        ${{ convertToLocaleString(room.Price.Fee.CleanFee) }}
      </div>
    </div>
    <div class="row serviceFee" v-if="room.Price.Fee.ServiceFee">
      <div class="col-6">服務費</div>
      <div class="col-6 text-end">
        ${{ convertToLocaleString(room.Price.Fee.ServiceFee) }}
      </div>
    </div>
    <div class="row taxFee" v-if="room.Price.Fee.tax">
      <div class="col-6">稅額</div>
      <div class="col-6 text-end">
        ${{ convertToLocaleString(room.Price.Fee.tax) }}
      </div>
    </div>
    <div class="row total">
      <div class="col-6">總額</div>
      <div class="col-6 text-end">${{ getTotal(room.Price, nightCount) }}</div>
    </div>
    <div class="row moreInfo d-md-none">
      <div
        class="btn"
        type="button"
        data-bs-target="#subMoreInfo"
        data-bs-toggle="offcanvas"
        aria-controls="offcanvasBottom"
      >
        更多資訊
      </div>
    </div>
  </div>

  <div
    class="offcanvas offcanvas-bottom subMoreInfoOffcanvas"
    tabindex="-1"
    id="subMoreInfo"
    aria-labelledby="subMoreInfoTitle"
  >
    <div class="offcanvas-header">
      <button
        type="button"
        class="btn-close text-reset"
        data-bs-dismiss="offcanvas"
        aria-label="Close"
      ></button>
      <p class="offcanvas-title" id="subMoreInfoTitle">價格詳情</p>
    </div>
    <div v-if="room.Price" class="offcanvas-body small">
      <div class="row roomPrice">
        <div class="col-10">
          <p>
            ${{ convertToLocaleString(room.Price.sweetPrice) }} x
            {{ Number(nightCount) }}晚
          </p>
        </div>
        <div class="col-2 text-end">
          ${{
            convertToLocaleString(
              Number(room.Price.sweetPrice) * Number(nightCount)
            )
          }}
        </div>
      </div>
      <div class="row cleanFee" v-if="room.Price.Fee.CleanFee">
        <div class="col-10">
          <p>清潔費</p>
          <p>此一次性費用為房東收取的清潔費。</p>
        </div>
        <div class="col-2 text-end">
          ${{ convertToLocaleString(room.Price.Fee.CleanFee) }}
        </div>
      </div>
      <div class="row serviceFee" v-if="room.Price.Fee.ServiceFee">
        <div class="col-10">
          <p>服務費</p>
          <p>
            服務費可以幫助我們維持平台的運作，並為您的旅程提供全天候支援。
            包含增值稅。
          </p>
        </div>
        <div class="col-2 text-end">
          ${{ convertToLocaleString(room.Price.Fee.ServiceFee) }}
        </div>
      </div>
      <div class="row taxFee" v-if="room.Price.Fee.tax">
        <div class="col-10"><p>稅額</p></div>
        <div class="col-2 text-end">
          ${{ convertToLocaleString(room.Price.Fee.tax) }}
        </div>
      </div>
    </div>
    <div class="offcanvas-footer">
      <div class="row total">
        <div class="col-10">總額</div>
        <div class="col-2 text-end">
          ${{ getTotal(room.Price, nightCount) }}
        </div>
      </div>
    </div>
  </div>
</template>
<style lang="scss" scoped>
.SubPriceDetail {
  .row {
    color: #717171;
    padding: 10px 0;
  }
  .total {
    border-top: 1px solid #ededed;
    color: #000;
    font-weight: 500;
  }
  .moreInfo {
    .btn {
      font-weight: 500;
      text-decoration: underline;
      padding: 0;
      text-align: end;
    }
  }
}
.subMoreInfoOffcanvas {
  .offcanvas-body {
    .row {
      font-size: 16px;
      font-weight: 300;
      padding: 10px 5px;
      .col-10 {
        p:nth-of-type(1) {
          font-weight: 500;
        }
      }
      .col-2 {
        color: #717171;
        font-weight: 500;
      }
    }
    .serviceFee,
    .cleanFee {
      .col-10 {
        p:nth-of-type(2) {
          color: #717171;
          font-size: 12px;
          padding: 8px 10px 8px 0;
          line-height: 1.2;
        }
      }
    }
  }
  .offcanvas-footer {
    padding: 20px 30px;
    .total {
      font-weight: 500;
      .col-2 {
        font-weight: 700;
      }
    }
  }
}

@media screen and(min-width:768px) {
  .SubPriceDetail {
    margin-top: 10px;
    padding: 30px 10px 0;
    border-top: 1px solid #ededed;
    h3 {
      font-size: 20px;
      padding: 0 0 10px;
    }
  }
}
</style>
<script>
export default {
  props: {
    room: {
      type: Object,
    },
    nightCount: {
      type: Number,
    },
  },
  methods: {
    convertToLocaleString(price) {
      return Number(price).toLocaleString();
    },
    getTotal(price, nightCount) {
      let feeTotal;
      let sweetprice = price.sweetPrice;
      let cleanFee = price.Fee.CleanFee;
      let taxFee = price.Fee.tax;
      let serviceFee = price.Fee.ServiceFee;
      if (cleanFee && taxFee && serviceFee) {
        feeTotal = Number(cleanFee) + Number(serviceFee) + Number(taxFee);
      } else if (!cleanFee && !taxFee && !serviceFee) {
        feeTotal = Number(serviceFee);
      } else if (cleanFee && !taxFee && serviceFee) {
        feeTotal = Number(serviceFee) + Number(cleanFee);
      } else if (!cleanFee && taxFee && serviceFee) {
        feeTotal = Number(taxFee) + Number(serviceFee);
      }
      return (Number(sweetprice) * nightCount + feeTotal).toLocaleString();
    },
  },
};
</script>