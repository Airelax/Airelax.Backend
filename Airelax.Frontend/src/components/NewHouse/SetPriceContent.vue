<template>
  <div class="contain">
    <div>
      <div>
        <div class="price-container">
          <span>NT$</span>
          <input
            type="number"
            name="price"
            id=""
            min="0"
            max="50000"
            onkeypress="return event.charCode >= 48 && event.charCode <= 57"
            @keyup="validPrice"
          />
        </div>
        <span class="per-day">每晚</span>
      </div>
      <p>價格需要介於1~50000</p>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.contain {
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;

  > div {
    width: 60%;
  }

  .price-container {
    display: flex;
    align-items: center;
    flex-wrap: wrap;
    width: 100%;
  }
}

input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
  -webkit-appearance: none;
  margin: 0;
}
span {
  font-size: 36px;
  display: block;
  text-align: left;
  padding-right: 5%;
}

/* Firefox */
input[type="number"] {
  -moz-appearance: textfield;
  text-align: center;
  padding: 20px;
  font-size: 36px;
  display: block;
  height: 80%;
  width: 80%;
  min-width: 200px;
  box-sizing: border-box;
}

p {
  margin-top: 90px;
  font-size: 24px;
  text-align: left;
  color: #aaa;
}
@media screen and (min-width: 768px) {
  .contain {
    .price-container {
      flex-wrap: nowrap;
      display: flex;
    }
  }
  span {
    font-size: 48px;
  }
  input[type="number"] {
    padding: 10px;
    font-size: 48px;
  }
  .per-day {
    font-size: 24px;
    display: block;
    text-align: right;
    padding: 0;
  }
}
</style>

<script>
export default {
  methods: {
    validPrice: function (e) {
      const input = e.target.value;
      if (input > 50000) e.target.value = 50000;
      else if (input < 0) e.target.value = 0;
    },
  },
};
</script>