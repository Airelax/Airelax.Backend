<template>
  <div class="main">
    <div class="title">
      <h2>心願單</h2>
    </div>
    <div class="list">
      <div class="column" v-for="item in wishLists" :key="item">
        <router-link
          :to="{
            name: 'wishList',
            params: { id: item.id },
          }"
          class="column-wrapper"
          @click="
            $store.state.wishListData = { id: item.id, wishName: item.name }
          "
        >
          <div class="image-container">
            <div
              class="image"
              :style="{ backgroundImage: 'url(' + item.cover + ')' }"
            ></div>
          </div>
          <p>{{ item.name }}</p>
        </router-link>
      </div>
    </div>
  </div>
</template>

<style scoped>
.main {
  margin-top: 120px; /**/
  padding: 0 24px;
}
.title {
  border-bottom: 1px solid rgb(235, 235, 235);
  margin-bottom: 24px;
}
.title h2 {
  font-size: 32px;
  font-weight: 600;
  text-align: start;
  margin-bottom: 15px;
  padding: 20px 0 24px;
}
.column {
  height: 84px;
  padding: 10px 0;
}
.column a {
  color: #222;
  text-decoration: none;
}
.column-wrapper {
  display: flex;
  cursor: pointer;
}
.column-wrapper p {
  font-size: 18px;
  font-weight: 600;
  margin: auto 0;
  overflow: auto;
}
.column-wrapper p::-webkit-scrollbar {
  display: none;
}
.image-container {
  margin-right: 16px;
}
.image {
  width: 64px;
  height: 64px;
  background-size: cover;
  background-color: #ebebeb;
  border-radius: 10px;
}
@media screen and (min-width: 768px) {
  #footer {
    display: block;
  }
  .list {
    display: flex;
    justify-content: space-between;
    flex-wrap: wrap;
  }
  .main {
    padding: 0 40px;
  }
  .column {
    width: calc(50% - 10px);
    min-height: 37.208vw;
    padding: 0;
  }
  .column-wrapper {
    flex-direction: column;
  }
  .column-wrapper p {
    height: 88px;
    font-size: 22px;
    text-align: start;
    padding: 16px 0 0;
  }
  .image-container {
    margin-right: 0;
  }
  .image {
    width: 100%;
    height: 22.787vw;
    border-radius: 20px;
  }
}
@media screen and (min-width: 1200px) {
  .main {
    padding: 0 80px;
  }
  .column {
    width: calc(33% - 13px);
    min-height: 21.86vw;
  }
  .image {
    height: 14.53vw;
  }
}
</style>

<script>
import axios from "axios";
export default {
  data() {
    return {
      wishLists: null,
    };
  },
  created() {
    const dataUrl = "/api/wishLists";
    axios
      .get(dataUrl)
      .then((res) => {
        this.wishLists = res.data;
      })
      .catch((err) => {
        console.log(err);
      });
  },
};
</script>