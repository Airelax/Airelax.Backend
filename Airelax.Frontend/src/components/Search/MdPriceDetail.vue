<template>
  <div
    v-if="price && fullWidth >= 768"
    class="collapse position-absolute"
    id="mdPriceDetail"
    style="top:0"
  >
    <div class="header d-flex align-items-center">
      <button
        type="button"
        class="btn-close text-reset"
        data-bs-toggle="collapse"
        href="#mdPriceDetail"
        aria-label="Close"
      ></button>
      <div class="title mx-auto">價格明細</div>
    </div>
    <div class="body">
      <div class="row">
        <div class="col">
          ${{ convertToLocaleString(Number(price.sweetPrice)) }}x{{
            nightCount
          }}晚
        </div>
        <div class="col">
          ${{ convertToLocaleString(Number(price.sweetPrice) * nightCount) }}
        </div>
      </div>
      <div class="row" v-if="price.Fee.CleanFee">
        <div class="col">清潔費</div>
        <div class="col">
          ${{ convertToLocaleString(Number(price.Fee.CleanFee)) }}
        </div>
      </div>
      <div class="row" v-if="price.Fee.ServiceFee">
        <div class="col">服務費</div>
        <div class="col">
          ${{ convertToLocaleString(Number(price.Fee.ServiceFee)) }}
        </div>
      </div>

      <div class="row" v-if="price.Fee.taxFee">
        <p class="col">稅額</p>
        <p class="col">
          ${{ convertToLocaleString(Number(price.Fee.taxFee)) }}
        </p>
      </div>
    </div>
  </div>

  <div class="modal fade" tabindex="-1" id="myModal" data-bs-backdrop="static" data-bs-keyboard="false"  v-if="price && fullWidth >= 768"> 
      <div class="modal-dialog modal-dialog-scrollable modal-dialog-centered modal-fullscreen-md-down">
          <div class="modal-content">
            <div class="modal-header">
              <div class="title mx-auto">價格明細</div>
              <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
          <div class="modal-body">
            <div class="body">
              <div class="row">
                <div class="col">
                  ${{ convertToLocaleString(Number(price.sweetPrice)) }}x{{
                    nightCount
                  }}晚
                </div>
                <div class="col">
                  ${{ convertToLocaleString(Number(price.sweetPrice) * nightCount) }}
                </div>
              </div>
              <div class="row" v-if="price.Fee.CleanFee">
                <div class="col">清潔費</div>
                <div class="col">
                  ${{ convertToLocaleString(Number(price.Fee.CleanFee)) }}
                </div>
              </div>
              <div class="row" v-if="price.Fee.ServiceFee">
                <div class="col">服務費</div>
                <div class="col">
                  ${{ convertToLocaleString(Number(price.Fee.ServiceFee)) }}
                </div>
              </div>

              <div class="row" v-if="price.Fee.taxFee">
                <p class="col">稅額</p>
                <p class="col">
                  ${{ convertToLocaleString(Number(price.Fee.taxFee)) }}
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
  </div>
</template>
<style lang="scss" scoped>
* {
  font-family: "Noto Sans TC", sans-serif;
}
.position-absolute {
  border: 0.5px solid #ededed;
  box-shadow: 0px 1px 15px 0.5px #aaa;
  background-color: #fff;
  border-radius: 18px;
  z-index: 18;
  width: 250px;
  left: 480px;
  top: 0;
  .header {
    color: #000;
    padding: 20px 0 20px 30px;
    font-weight: 500;
    .btn-close {
      font-size: 12px;
      opacity: 1;
    }
  }
  .body {
    font-weight: 400;
    border-top: 0.5px solid #ededed;
    padding-bottom: 10px;
    .row {
      padding: 0 20px;
      margin: 10px 0;
      .col:nth-of-type(1) {
        text-align: start;
      }
      .col:nth-of-type(2) {
        text-align: end;
      }
    }
  }
}
.img{
  width: 1.2rem;
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
    }
  },
  methods: {
    convertToLocaleString(price) {
      return price.toLocaleString();
    }
  },
  data() {
    return {
      fullWidth: 0,
    };
  },
  watch: {
    fullWidth(val) {
      this.fullWidth = val;
    }
  },
  mounted() {
    const vm = this;
    this.fullWidth = document.body.clientWidth;
    window.addEventListener("resize", function () {
      vm.fullWidth = document.body.clientWidth;
    });
  },
};
</script>