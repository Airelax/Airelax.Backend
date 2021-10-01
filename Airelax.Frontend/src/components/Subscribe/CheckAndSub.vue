<template>
  <div class="row checkAndSub">
    <p>
      選擇以下按鈕即代表我同意 <a href="#">《房屋守則》</a> ,
      <a href="#">安全注意事項</a>,
      <a href="#">Airelax 的社交距離指南和其他防疫指南</a>,
      <a href="">退訂政策</a> 和 <a href="">《旅客退款政策》</a>。
      此外，我也同意支付顯示的總金額（含住宿稅和服務費）。
      Airelax現已在該地區代收彙繳政府徵收的住宿稅。
    </p>
    <a :href="href" class="btn">申請預訂</a>
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

export default {
  props: {
    token: {
      type: String,
    },
    orderId: {
      type: String,
    }
  },
  data() {
    return {
      href: `/api/system/${this.orderId}/${this.token}`
    }
  },
  mounted() {
  }
};
</script>