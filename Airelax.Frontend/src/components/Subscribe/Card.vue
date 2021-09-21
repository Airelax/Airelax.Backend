<template>
  <!-- <div class="row">
    <div class="form-floating">
      <input
        class="form-control"
        id="cardnumber"
        type="text"
        pattern="[0-9]*"
        inputmode="numeric"
      />
      <label for="cardnumber">卡號</label>
    </div>
  </div>
  <div class="row">
    <div class="col-6 form-floating">
      <input
        class="form-control"
        id="expirationdate"
        type="text"
        pattern="[0-9]*"
        inputmode="numeric"
      />
      <label for="expirationdate">到期日</label>
    </div>
    <div class="col-6 form-floating">
      <input
        class="form-control"
        id="securitycode"
        type="text"
        pattern="[0-9]*"
        inputmode="numeric"
      />
      <label for="securitycode">安全碼</label>
    </div>
  </div> -->

  <div id="ECPayPayment"><!--渲染--></div>
</template>
<script>
//import axios from 'axios';

export default {
  mounted() {
    // const envi = 'Stage';
    // window.handlerMsg = function (errMsg) {
    //   //console.log('Callback Message: ' + errMsg);
    //   if (errMsg != null)
    //     console.log(errMsg);
    // }
    // window.token = this.token;
    // window.$(function () {
    //
    //   //初始化SDK畫面
    //   window.ECPay.initialize(envi, 1, function () {
    //     console.log(window.token);
    //     try {
    //       window.ECPay.createPayment(window.token, window.ECPay.Language.zhTW, msg => window.handlerMsg(msg));
    //     } catch (err) {
    //       console.log(err);
    //     }
    //   });

    //消費者選擇完成付款方式,取得PayToken 
    //   $('#').click(function () {
    //
    //     try {
    //       window.ECPay.getPayToken(function (paymentInfo, errMsg) {
    //         //console.log("response => getPayToken(paymentInfo, errMsg):", paymentInfo, errMsg);
    //         if (errMsg != null) {
    //           ErrHandle(errMsg);
    //           return;
    //         }
    //         $("#PayToken").val(paymentInfo.PayToken);
    //        
    //         return true;
    //       });
    //     } catch (err) {
    //       console.log(err);
    //     }
    //
    //     return false;
    //   });
    // });
    // });
  }
}
</script>



