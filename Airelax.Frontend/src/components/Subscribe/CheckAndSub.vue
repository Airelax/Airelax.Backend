<template>
  <div class="row checkAndSub">
    <p>
      選擇以下按鈕即代表我同意 <a href="#">《房屋守則》</a> ,
      <a href="#">安全注意事項</a>,
      <a href="#">Airbnb 的社交距離指南和其他防疫指南</a>,
      <a href="">退訂政策</a> 和 <a href="">《旅客退款政策》</a>。
      此外，我也同意支付顯示的總金額（含住宿稅和服務費）。
      Airbnb現已在該地區代收彙繳政府徵收的住宿稅。
    </p>
    <div class="btn" @click="createOrder">申請預訂</div>
  </div>
</template>
<style lang="scss" scoped>
.checkAndSub {
  p {
    margin: 10px 0;
    font-size: 12px;
    line-height: 1.5;
    font-weight: 400;
  }

  .btn {
    font-weight: 500;
    color: #fff;
    background-color: #ff385c;
    background: linear-gradient(#ff385c, #ff6c87, #ff385c, 180deg);
    padding: 15px 0;
    margin-bottom: 10px;
    border-radius: 15px;
  }

  .btn:active {
    background-color: #fff;
    color: #ff385c;
    border: 1px solid #ededed;
  }
}
</style>
<script>
import axios from "axios";

export default {
  data() {
    const isDateEmpty = Object.keys(this.$store.state.date).length === 0;
    return {
      OrdersInput: {
        houseId: this.$route.params.houseId,
        startDate: isDateEmpty
            ? null
            : this.$store.state.date.start
                .replace(/[年]/, "-")
                .replace(/[月]/, "-")
                .replace("日", ""),
        endDate: isDateEmpty
            ? null
            : this.$store.state.date.end
                .replace(/[年]/, "-")
                .replace(/[月]/, "-")
                .replace("日", ""),
        adult: this.$store.state.adult,
        child: this.$store.state.child,
        baby: this.$store.state.toddler,
      },
    };
  },

  mounted() {
    console.log(this.OrdersInput.startTime);
    console.log(this.OrdersInput.endTime);
  },
  methods: {
    createOrder() {
      console.log(this.OrdersInput.json);

      const params = new URLSearchParams();
      params.append('MerchantID', '2000132');
      params.append('MerchantTradeNo', 'air12342431010');
      params.append('MerchantTradeDate', '2021/09/13 14:11:30');
      params.append('PaymentType', 'aio');
      params.append('TotalAmount', '1000');
      params.append('TradeDesc', 'test');
      params.append('ItemName', 'test商品10元*1#秘密100元*2');
      params.append('ChoosePayment', 'All');
      params.append('ReturnURL', 'http://127.0.0.1:8080');
      params.append('EncryptType', '1');


      axios("https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut/V5", {
        method: "POST",
        headers: {
          "Content-Type": "application/x-www-form-urlencoded",
          "Access-Control-Allow-Origin": "*"
        },
        params: params
      }).then(res => {
        console.log(res);

      }).catch(err => console.log(err));


      // axios("/api/orders", {
      //   method: "POST",
      //   headers: {
      //     "Content-Type": "application/json",
      //   },
      //   data: this.OrdersInput,
      // })
      //   .then(function (response) {
      //     if (response.status === 200) {
      //       console.log(response);
      //     }
      //   })
      //   .catch(function (error) {
      //     alert(error.toString());
      //   });


    },
  },
};
</script>