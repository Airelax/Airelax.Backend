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
import axios from 'axios';

export default {
  created(){
      const Environment = 'STAGE'; //請設定要連線的環境: 測試 STAGE ,正式PROD
        const envi = GetEnvi(Environment);
       
    axios("/api/Orders",{
      method: "POST",
      headers:{
        "content-type":"application/json"
      },
      data
    })


     ECPay.initialize(envi, 1, function (errMsg) {
            if (_token === '') {
                _token = prompt('請填入Token: ');
            }

            try {
                ECPay.createPayment(_token, ECPay.Language.zhTW, function (errMsg) {
                    //console.log('Callback Message: ' + errMsg);
                    if (errMsg != null)
                        ErrHandle(errMsg);
                });
            } catch (err) {
                ErrHandle(err);
            }
        });
  }
}
</script>



