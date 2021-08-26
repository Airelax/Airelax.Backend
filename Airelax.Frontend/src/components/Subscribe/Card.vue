<template>
  <div class="row">
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
  </div>
</template>


