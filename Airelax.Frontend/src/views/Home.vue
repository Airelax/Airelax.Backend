<template>
  <div class="head">
    <SearchBar></SearchBar>
    <div class="kanban">
      <p>想去哪?別擔心!</p>
      <p>你最近哪裡都去不了!</p>
      <button class="goTo">立即瀏覽</button>
    </div>
  </div>
  <div class="body" v-if="$store.state.isBodyShow">
    <div class="around">
      <h2>探索周邊</h2>
      <div class="scrollbar">
        <div class="yuan-container">
          <div class="yuan-row">
            <div class="around-div">
              <a href="#" @click.prevent="SearchLocation">
                <img src="../assets/image/Home/around.png" />
                <div class="item mx-lg-2">
                  <span>台北</span
                  ><span>{{ getRandomNumber(30, 120) }}分鐘車程</span>
                </div>
              </a>
            </div>
            <div class="around-div">
              <a href="#" @click.prevent="SearchLocation">
                <img src="../assets/image/Home/around2.png" />
                <div class="item mx-lg-2">
                  <span>台南</span
                  ><span>{{ getRandomNumber(30, 120) }}分鐘車程</span>
                </div>
              </a>
            </div>
            <div class="around-div">
              <a href="#" @click.prevent="SearchLocation">
                <img src="../assets/image/Home/around3.png" />
                <div class="item mx-lg-2">
                  <span>高雄</span
                  ><span>{{ getRandomNumber(30, 120) }}分鐘車程</span>
                </div>
              </a>
            </div>
            <div class="around-div">
              <a href="#" @click.prevent="SearchLocation">
                <img src="../assets/image/Home/around4.png" />
                <div class="item mx-lg-2">
                  <span>桃園</span
                  ><span>{{ getRandomNumber(30, 120) }}分鐘車程</span>
                </div>
              </a>
            </div>
          </div>
          <div class="yuan-row">
            <div class="around-div">
              <a href="#" @click.prevent="SearchLocation">
                <img src="../assets/image/Home/around5.png" />
                <div class="item mx-lg-2">
                  <span>新北市</span
                  ><span>{{ getRandomNumber(30, 120) }}分鐘車程</span>
                </div>
              </a>
            </div>
            <div class="around-div">
              <a href="#" @click.prevent="SearchLocation">
                <img src="../assets/image/Home/around6.png" />
                <div class="item mx-lg-2">
                  <span>花蓮</span
                  ><span>{{ getRandomNumber(30, 120) }}分鐘車程</span>
                </div>
              </a>
            </div>
            <div class="around-div">
              <a href="#" @click.prevent="SearchLocation">
                <img src="../assets/image/Home/around7.png" />
                <div class="item mx-lg-2">
                  <span>台東市</span
                  ><span>{{ getRandomNumber(30, 120) }}分鐘車程</span>
                </div>
              </a>
            </div>
            <div class="around-div">
              <a href="#" @click.prevent="SearchLocation">
                <img src="../assets/image/Home/around8.png" />
                <div class="item mx-lg-2">
                  <span>恆春</span
                  ><span>{{ getRandomNumber(30, 120) }}分鐘車程</span>
                </div>
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="dontWorry">
      <div class="item">
        還不知道想去哪嗎？<br />別擔心。
        <button class="goTo" @click="freeGo">隨心所欲</button>
      </div>
    </div>
    <div class="anyCorner">
      <h2>任何角落都能找到舒適住宿</h2>
      <div class="row everyCornerComfortable">
        <div class="scrollArea">
          <div
            class="col-11 fs-4 col-sm-6 p-2 p-sm-2 col-md-4 col-xl-3 feature"
          >
            <img
              class="w-100"
              src="../assets/image/Home/family.png"
              alt="戶外度假勝地"
            />
            <p>戶外度假勝地</p>
          </div>
          <div
            class="col-11 fs-4 col-sm-6 p-2 p-sm-2 col-md-4 col-xl-3 feature"
          >
            <img
              class="w-100"
              src="../assets/image/Home/family2.png"
              alt="獨特房源"
            />
            <p>獨特房源</p>
          </div>
          <div
            class="col-11 fs-4 col-sm-6 p-2 p-sm-2 col-md-4 col-xl-3 feature"
          >
            <img
              class="w-100"
              src="../assets/image/Home/family3.png"
              alt="整套房源"
            />
            <p>整套房源</p>
          </div>
          <div
            class="col-11 fs-4 col-sm-6 p-2 p-sm-2 col-md-4 col-xl-3 feature"
          >
            <img
              class="w-100"
              src="../assets/image/Home/family4.png"
              alt="可攜帶寵物"
            />
            <p>可攜帶寵物</p>
          </div>
        </div>
      </div>
    </div>
    <div class="findFresh">
      <h2>發掘好玩新鮮事</h2>
      <div class="freshThing">
        <div class="scrollArea">
          <div class="col-11 fs-4 col-sm-6 p-2 p-sm-2 col-md-4 col-xl-4 fresh">
            <img
              class="w-100"
              src="../assets/image/Home/haveFun.png"
              alt="尋找附近的難忘體驗"
            />
            <p>體驗</p>
            <p class="fs-6">尋找附近的難忘體驗。</p>
          </div>
          <div class="col-11 fs-4 col-sm-6 p-2 p-sm-2 col-md-4 col-xl-4 fresh">
            <img
              class="w-100"
              src="../assets/image/Home/haveFun2.png"
              alt="由體驗達人舉辦的互動式直播體驗。"
            />
            <p>線上體驗</p>
            <p class="fs-6">由體驗達人舉辦的互動式直播體驗。</p>
          </div>
          <div class="col-11 fs-4 col-sm-6 p-2 p-sm-2 col-md-4 col-xl-4 fresh">
            <img
              class="w-100"
              src="../assets/image/Home/haveFun3.png"
              alt="參加線上體驗，安坐家中暢遊全世界。"
            />
            <p>精選系列：浪跡天涯</p>
            <p class="fs-6">參加線上體驗，安坐家中暢遊全世界。</p>
          </div>
        </div>
      </div>
    </div>
    <div class="rent">
      <div class="item">
        <h2>開始出租吧</h2>
        分享你的空間，賺取額外收入，開拓新機會。
        <router-link to="/become-host" style="text-decoration: none">
          <button class="goTo">了解詳情</button>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import SearchBar from "../components/Home/SearchBar";

export default {
  components: {
    SearchBar,
  },
  methods: {
    SearchLocation(e) {
      console.log(e.target);
      this.$store.state.destination = e.target.querySelector("span").innerText;
      this.$router.push({
        path: "search",
        query: {
          location: this.$store.state.destination,
        },
      });
    },

    freeGo() {
      this.$store.state.destination = "台北";
      this.$router.push({
        path: "/search",
        query: {
          location: this.$store.state.destination,
        },
      });
    },
    getRandomNumber(min, max) {
      return Math.floor(Math.random() * (max - min + 1)) + min;
    },
  },
  mounted() {
    this.$store.state.isBodyShow = true;
  },
};
</script>

<style lang="scss" scoped>
@import "../assets/css/reset.css";

.everyCornerComfortable,
.freshThing {
  overflow: hidden;

  .scrollArea {
    display: flex;
    flex-wrap: nowrap;
    overflow-x: scroll;

    .feature,
    .fresh {
      img {
        border-radius: 20px;
      }

      p {
        font-weight: 700;
        padding-top: 15px;
      }

      .fs-6 {
        font-weight: 400;
      }
    }
  }
}

.everyCornerComfortable {
  height: 450px;

  .scrollArea {
    height: 470px;
  }
}

.freshThing {
  height: 560px;

  .scrollArea {
    height: 580px;
  }
}

body * {
  font-family: Circular, -apple-system, BlinkMacSystemFont, Roboto,
    "Helvetica Neue", sans-serif;
  text-align: left;
}

body::-webkit-scrollbar {
  display: none;
}

.around .around-div,
.around .yuan-row,
.family .yuan-row,
.haveFun .yuan-row {
  display: flex;
}

.notice .item,
.kanban p,
.goTo,
.body h2,
.around-div .item span:nth-child(1),
.family-div .item span:nth-child(1),
.fun-div .item span:nth-child(1),
.dontWorry .item,
.family .family-div span,
.haveFun .fun-div span {
  font-weight: 700;
}

.head {
  height: 125vw;
  background-size: cover;
  background-image: url(https://a0.muscache.com/im/pictures/0c38042b-8685-4180-8d9b-12a6892ac6d8.jpg?im_w=720);
  position: relative;
}

.notice {
  height: 50px;
  text-align: center;
  background-color: #222222;
}

.notice .item {
  line-height: 50px;
  font-size: 1vw;
  color: #a3a3a3;
  margin: auto;
}

.search {
  width: 84.375vw;
  height: 48px;
  background-color: chartreuse;
  border-radius: 50px;
  margin: 0 auto 32px;
}

.kanban {
  line-height: 7.90625vw;
  text-align: center;
  margin: auto;
  position: absolute;
  top: 25%;
  left: 0%;
  right: 0;
}

.kanban p {
  font-size: 25px;
  color: #000000;
  padding-bottom: 12px;
  margin: auto;
  display: block;
  text-align: center;
}

.goTo {
  width: 27.5vw;
  height: 10.625vw;
  font-size: 4.375vw;
  color: #000;
  background-color: #fff;
  border: none;
  border-radius: 2.5vw;
  cursor: pointer;
  text-align: center;
  line-height: 0 !important;
  text-decoration: none !important;
}

.body {
  padding: 15vw 7.5vw;
}

.body h2 {
  line-height: normal;
  font-size: 6.875vw;
  color: #222222;
  text-align: left;
}

.scrollbar {
  overflow: auto hidden;
}

.scrollbar::-webkit-scrollbar {
  display: none;
}

.scrollbar .around-div a,
.scrollbar .fun-div a,
.scrollbar .family-div a {
  font-size: 0;
  text-decoration: none;
}

.around .yuan-container {
  width: 239.9vw;
}

.around .yuan-row {
  justify-content: space-between;
  padding-top: 3.5vw;
}

.around .yuan-row:nth-child(1) {
  padding-top: 5vw;
}

.around .around-div a {
  display: flex;
}

.around .around-div img {
  width: 22.5vw;
  height: 22.5vw;
  border-radius: 4vw;
}

.around .around-div .item {
  width: 29vw;
  margin: auto;
  position: relative;
  margin-left: 4vw;
}

.around .around-div .item span {
  position: absolute;
}

.around .around-div .item span {
  line-height: 7vw;
  font-size: 5vw;
  color: #222222;
  display: block;
}

.around .around-div .item span:nth-child(1) {
  bottom: 5px;
}

.around .around-div .item span:nth-child(2) {
  font-weight: normal;
}

.dontWorry {
  height: 86.875vw;
  background-image: url(../assets/image/Home/dontWorry.png);
  background-size: cover;
  border-radius: 5vw;
  margin: 15vw 0;
  padding: 10vw;
}

.dontWorry .item {
  line-height: 7.5vw;
  font-size: 6.25vw;
  text-align: center;
  color: #222222;
}

.dontWorry .goTo {
  color: #fff;
  background-color: #222222;
  margin: 5vw auto 0;
  display: block;
}

.family .yuan-row {
  padding-top: 5vw;
}

.family .family-div:nth-child(1),
.family .family-div:nth-child(2),
.family .family-div:nth-child(3) {
  margin-right: 3.75vw;
}

.family .family-div img {
  width: 58.75vw;
  height: 58.75vw;
  border-radius: 2.5vw;
}

.family .family-div span {
  font-size: 5.625vw;
  color: #222222;
  margin-top: 2.5vw;
  display: block;
}

.haveFun {
  margin: 15vw 0;
}

.haveFun .yuan-row {
  padding-top: 5vw;
}

.haveFun .fun-div:nth-child(1),
.haveFun .fun-div:nth-child(2) {
  margin-right: 3.75vw;
}

.haveFun .fun-div img {
  width: 85vw;
  height: 85vw;
  border-radius: 2.5vw;
}

.haveFun .fun-div span {
  font-size: 5.625vw;
  color: #222222;
  margin-top: 2.5vw;
  display: block;
}

.haveFun .fun-div:nth-child(1) .item,
.haveFun .fun-div:nth-child(2) .item,
.haveFun .fun-div:nth-child(3) .item {
  font-size: 4.375vw;
  font-weight: normal;
  margin-top: 1.25vw;
}

.rent {
  height: 45rem;
  background-image: url(../assets/image/Home/rent.png);
  background-size: cover;
  border-radius: 5vw;
  padding: 10vw;
}

.rent .item {
  line-height: 5vw;
  font-size: 4.375vw;
  text-align: center;
  color: #fff;
}

.rent .item h2 {
  font-size: 6.25vw;
  text-align: center;
  color: #fff;
  margin: 0 0 4.0625vw;
  position: relative;
}

.rent .item .goTo {
  margin: 4.6875vw auto 0;
  display: block;
}

.around-div {
  .item,
  img {
    pointer-events: none;
  }
}

@media screen and (min-width: 768px) {
  .everyCornerComfortable {
    height: 450px;

    .scrollArea {
      height: 470px;
    }
  }
  .freshThing {
    height: 560px;

    .scrollArea {
      height: 580px;
    }
  }

  .notice {
    height: 7.554vw;
  }
  .notice .item {
    line-height: 7.554vw;
    font-size: 1.82292vw;
  }
  .search {
    width: 93.49vw;
    height: 6.25vw;
    background-color: brown;
    margin: 0 auto;
  }
  .head {
    background-image: url(https://a0.muscache.com/im/pictures/57b9f708-bb12-498c-bc33-769f8fc43e63.jpg?im_w=2560);
  }
  .kanban {
    text-align: start;
    padding: 0px 5.20834vw;
    margin-top: 31vw;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
  }
  .kanban p {
    color: #000000;
    line-height: 4.49219vw;
    font-size: 50px;
    //text-align: start;
    margin: auto;
    padding: 10px 0;
    text-align: center;
  }
  .goTo {
    width: 11.46vw;
    height: 4.428vw;
    font-size: 1.82292vw;
    border-radius: 1vw;
  }
  .body {
    padding: 10.41667vw 5.20834vw;
  }
  .body h2 {
    line-height: 5.98958vw;
    font-size: 3.38542vw;
  }
  .around .yuan-container {
    width: 124vw;
  }
  .around .around-div img {
    width: 9.375vw;
    height: 9.375vw;
    border-radius: 1.65vw;
  }
  .around .around-div .item {
    width: 12.5vw;
  }
  .around .around-div .item span {
    line-height: normal;
    font-size: 2.08333vw;
  }
  .around .yuan-row:nth-child(1) {
    padding: 2.08333vw 0 0 0;
  }
  .around .yuan-row:nth-child(2) {
    padding: 2.08333vw 0 0 0;
  }
  .dontWorry {
    height: 47.136vw;
    background-image: url(../assets/image/Home/dontWorry-md.png);
    background-position: -8.5vw;
    border-radius: 2vw;
    padding: 0 5.20834vw;
    margin: 6.25vw 0;
  }
  .dontWorry .item {
    height: 100%;
    line-height: 4.6875vw;
    font-size: 3.90625vw;
    text-align: start;
    display: flex;
    flex-direction: column;
    justify-content: center;
  }
  .dontWorry .goTo {
    margin: 2.60417vw 0 0;
  }
  .family .yuan-row {
    padding-top: 2.08333vw;
  }
  .family .family-div:nth-child(1),
  .family .family-div:nth-child(2),
  .family .family-div:nth-child(3) {
    margin-right: 2.47366vw;
  }
  .family .family-div img {
    width: 28.212vw;
    height: 28.212vw;
    border-radius: 1.325vw;
  }
  .family .family-div span {
    font-size: 2.34375vw;
    margin-top: 1.041667vw;
  }
  .haveFun {
    margin: 6.25vw 0;
  }
  .haveFun .yuan-row {
    padding-top: 2.08333vw;
  }
  .haveFun .fun-div img {
    width: 28.212vw;
    height: 28.212vw;
    border-radius: 1.325vw;
  }
  .haveFun .fun-div:nth-child(1),
  .haveFun .fun-div:nth-child(2) {
    margin-right: 2.47366vw;
  }
  .haveFun .fun-div span {
    line-height: 2.34375vw;
    font-size: 2.34375vw;
    margin-top: 1.041667vw;
  }
  .haveFun .fun-div .item {
    font-size: 1.82292vw !important;
    text-align: justify;
    margin-top: 0.520833vw !important;
  }
  .rent {
    height: 47.137vw;
    background-image: url(../assets/image/Home/rent-md.png);
    background-position: -8.5vw;
    border-radius: 2vw;
    padding: 0;
  }
  .rent .item {
    width: 40%;
    height: 100%;
    line-height: 2.60417vw;
    font-size: 2.08333vw;
    text-align: start;
    display: flex;
    flex-direction: column;
    justify-content: center;
    padding-left: 5.20834vw;
  }
  .rent .item h2 {
    line-height: 4.6875vw;
    font-size: 3.90625vw;
    text-align: start;
    padding-bottom: 1.5625vw;
    margin: 0;
  }
  .rent .item .goTo {
    margin: 2.60417vw 0 0;
  }
}

@media screen and (min-width: 1280px) {
  .freshThing {
    height: 540px;

    .scrollArea {
      height: 560px;
    }
  }

  .notice {
    height: 58px;
  }
  .notice .item {
    line-height: 58px;
    font-size: 14px;
  }
  .search {
    width: 850px;
    height: 64px;
    margin: 0 auto;
  }
  .head {
    height: 85vh;
    background-position: bottom;
    padding-top: 80px;
  }
  .kanban {
    margin: 16.5vh 0 0;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
  }
  .kanban p {
    width: 29vw;
    line-height: 4.3125vw;
    font-size: 3.75vw;
    //text-align: left;
    margin: auto;
    text-align: center;
  }
  .goTo {
    width: 6.875vw;
    height: 2.6565vw;
    font-size: 1.09375vw;
    border-radius: 0.7vw;
  }
  .body {
    padding-top: 5.20834vw;
  }
  .body h2 {
    line-height: normal;
    font-size: 2.5vw;
  }
  .scrollbar {
    overflow: hidden;
  }
  .around .yuan-container {
    width: 99vw;
  }
  .around .yuan-row:nth-child(1) {
    padding-top: 1.25vw;
  }
  .around .yuan-row:nth-child(2) {
    padding-top: 1.04166vw;
  }
  .around .around-div {
    width: 23vw;
  }
  .around .around-div img {
    width: 4.844vw;
    height: 4.844vw;
    border-radius: 0.6vw;
  }
  .around .around-div .item span {
    font-size: 1.25vw;
  }
  .dontWorry {
    height: 31.407vw;
    background-image: url(../assets/image/Home/dontWorry-md.png);
    background-position: 0;
    border-radius: 1.5vw;
    padding: 0 5.20834vw;
    margin: 4.25vw 0;
  }
  .dontWorry .goTo {
    width: 8.75vw;
    height: 3.75vw;
    font-size: 1.25vw;
  }
  .family .yuan-row {
    padding-top: 1.25vw;
  }
  .family-div {
    width: 19.5rem;
  }
  .family .family-div img {
    width: 21.081vw;
    height: 21.081vw;
    border-radius: 0.6vw;
  }
  .family .family-div:nth-child(1),
  .family .family-div:nth-child(2),
  .family .family-div:nth-child(3) {
    margin-right: 1.75vw;
  }
  .family .family-div span {
    font-size: 1.40625vw;
    margin-top: 0.625vw;
  }
  .haveFun {
    margin: 4.25vw 0;
  }
  .haveFun .yuan-row {
    padding-top: 1.25vw;
  }
  .haveFun .fun-div {
    width: 26.5rem;
  }
  .haveFun .fun-div img {
    border-radius: 0.6vw;
  }
  .haveFun .fun-div span {
    line-height: 1.71875vw;
    font-size: 1.40625vw;
    margin-top: 0.625vw;
  }
  .haveFun .fun-div .item {
    line-height: 1.40625vw;
    font-size: 1.09375vw !important;
    margin-top: 0.3125vw !important;
  }
  .rent {
    height: 31.407vw;
    border-radius: 1vw;
    background-position: 0;
  }
  .rent .item {
    font-size: 1.40625vw;
  }
  .rent .item h2 {
    font-size: 3.75vw;
    padding-bottom: 0.9375vw;
  }
  .rent .item .goTo {
    width: 8.75vw;
    height: 3.75vw;
    font-size: 1.25vw;
  }
}

@media screen and (min-width: 1440px) {
  .everyCornerComfortable {
    height: 540px;

    .scrollArea {
      height: 560px;
    }
  }
  .freshThing {
    height: 720px;

    .scrollArea {
      height: 740px;
    }
  }
}
</style>