<template>
  <Layout :title="'房源的位置在哪裡？'">
    <div class="container">
      <div class="input-box">
        <div class="input-group">
          <label for="address-input">
            <img :src="require('@/assets/pic/rent_page/location.svg')" alt="">
          </label>
          <input type="text" id="address-input" placeholder="請輸入你的地址">
        </div>
        <button id="my-location" data-bs-toggle="modal" data-bs-target="#mapCheckModal"
                class="btn btn-light w-100">
          <div class="d-flex align-items-center w-100">
            <span class="">
              <img :src="require('@/assets/pic/rent_page/nav.svg')" alt="">
            </span>
            <span class="h-100 w-100">使用我目前的位置</span>
          </div>
        </button>
      </div>

    </div>
    <div class="modal fade" id="mapCheckModal" tabindex="-1">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">確認你的地址</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
          </div>
          <div class="modal-body">
            <form class="row">
              <label for="street" class="row form-group inside-label">
                <div class="hint" :class="{'d-none':isStreet}">{{ street }}</div>
                <input type="text"
                       v-on:focus="clearPlaceholder(street,$event)"
                       v-on:focusout="setPlaceholder(street,$event)"
                       :placeholder="street"
                       id="street"
                       v-model="address.street">
              </label>
              <label for="town" class="row form-group inside-label">
                <div class="hint" :class="{'d-none':isTown}">{{ town }}</div>
                <input type="text" v-on:focus="clearPlaceholder(town,$event)"
                       v-on:focusout="setPlaceholder(town,$event)" :placeholder="town" id="town" v-model="address.town">
              </label>
              <label for="city" class="row form-group inside-label">
                <div class="hint" :class="{'d-none':isCity}">{{ city }}</div>
                <input type="text" v-on:focus="clearPlaceholder(city,$event)"
                       v-on:focusout="setPlaceholder(city,$event)" :placeholder="city" id="city" v-model="address.city">
              </label>
              <label for="zipcode" class="row form-group inside-label">
                <div class="hint" :class="{'d-none':isZipcode}">{{ zipcode }}</div>
                <input type="text" v-on:focus="clearPlaceholder(zipcode,$event)"
                       v-on:focusout="setPlaceholder(zipcode,$event)" :placeholder="zipcode" id="zipcode"
                       v-model="address.zipcode">
              </label>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">取消</button>
            <button type="button" class="btn btn-dark">看起來很棒</button>
          </div>
        </div>
      </div>
    </div>
  </Layout>
</template>

<script>
import Layout from "../../components/NewHouse/Layout.vue";

export default {
  name: "SetLocation",
  data() {
    return {
      street: "街道地址",
      zipcode: "郵遞區號(選填)",
      town: "鄉/鎮/區",
      city: "縣市",
      isStreet: true,
      isZipcode: true,
      isTown: true,
      isCity: true,
      address: {
        city: "",
        town: "",
        zipcode: "",
        street: ""
      }
    }
  },
  methods: {
    clearPlaceholder: function (hint, e) {
      e.target.placeholder = "";
      if (hint === this.street) this.isStreet = false;
      if (hint === this.zipcode) this.isZipcode = false;
      if (hint === this.town) this.isTown = false;
      if (hint === this.city) this.isCity = false;
    },
    setPlaceholder: function (hint, e) {
      if (e.target.value) {
        if (hint === this.street) this.isStreet = false;
        if (hint === this.zipcode) this.isZipcode = false;
        if (hint === this.town) this.isTown = false;
        if (hint === this.city) this.isCity = false;
        return;
      }
      e.target.placeholder = hint;
      if (hint === this.street) this.isStreet = true;
      if (hint === this.zipcode) this.isZipcode = true;
      if (hint === this.town) this.isTown = true;
      if (hint === this.city) this.isCity = true;
    }
  },
  components: {
    Layout
  }
}
</script>

<style lang="scss" scoped>
.container {
  background-image: url("../../assets/pic/rent_page/staticmap.png");
  height: 100%;
  background-size: 100% 100%;
  padding-top: 50px;
  position: relative;
}

img {
  width: 32px;
  height: 32px;
}

.input-box {
  background-color: #fff;
  border-radius: 16px;

  * {
    background-color: transparent;
  }

  &:focus-within {
    #my-location {
      display: block;
    }
  }
}

#address-input {
  border: none;
  width: 100%;

  &:focus-visible {
    outline: none;
  }
}

#my-location {
  padding: 0;
  display: none;
  border: none;

  span {
    padding: 5px;
    text-align: left;
  }
}

.input-group {
  flex-wrap: nowrap;

  label {
    padding: 5px;
  }

  box-sizing: border-box;

  &:focus-within {
    border: 1px saddlebrown solid;
    border-radius: 16px 16px 0 0;
  }
}


.inside-label {
  border: 1px solid rgb(113, 113, 113);
  padding: 15px 10px 10px 10px;
  position: relative;

  &:not(:last-child) {
    border-bottom: none;
  }

  .hint {
    color: rgb(113, 113, 113);
    text-align: left;
    font-size: 12px;
    position: absolute;
    top: 0;
  }

  input {
    border: none;

    &:focus {
      border: none;
      outline: none;
    }
  }

  &:focus-within {
    border: 2px black solid;

    .hint {
      display: block;
    }
  }
}

@media screen and (min-width: 768px) {
  #mapCheckOffcanvas {
    display: none;
  }
}
</style>