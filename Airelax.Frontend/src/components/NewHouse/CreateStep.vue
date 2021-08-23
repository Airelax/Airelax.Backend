<template>
  <div class="contain">
    <div>
      <h2>完成房源發布</h2>
      <ul>
        <li v-for="houseSource in houseSources" :key="houseSource.id">
          <router-link :to="houseSource.navigation">
            <Publish :houseSource="houseSource"></Publish>
          </router-link>
        </li>
      </ul>
    </div>
    <div>
      <h2>開始建立新房源</h2>
      <div>
        <router-link :to="{ path: newHouse.navigation }">
          <Publish :houseSource="newHouse">
            <svg
              viewBox="0 0 32 32"
              xmlns="http://www.w3.org/2000/svg"
              role="presentation"
              focusable="false"
              class="add"
            >
              <path d="m2 16h28m-14-14v28"></path>
            </svg>
          </Publish>
        </router-link>
        <button>
          <Publish :houseSource="copyHouse">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              viewBox="0 0 32 32"
              role="presentation"
              focusable="false"
              class="copy"
            >
              <path
                d="M25 5a4 4 0 0 1 4 4v17a5 5 0 0 1-5 5H12a5 5 0 0 1-5-5V10a5 5 0 0 1 5-5h13zm0 2H12a3 3 0 0 0-3 3v16a3 3 0 0 0 3 3h12a3 3 0 0 0 3-3V9a2 2 0 0 0-2-2zm-3-6v2H11a6 6 0 0 0-5.996 5.775L5 9v13H3V9a8 8 0 0 1 7.75-7.996L11 1h11z"
              ></path>
            </svg>
          </Publish>
        </button>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
ul {
  padding: 0;
  margin: 0;
}
li {
  list-style: none;
  margin: 15px 0;
}

h2 {
  text-align: left;
  margin-bottom: 20px;
  font-weight: 900;
  font-size: 22px;
}

.contain {
  padding: 30px;
}

a,
button {
  text-decoration: none;
  display: block;
}

button {
  background-color: #fff;
  border: none;
  width: 100%;
  padding: 0;
  margin-top: 15px;
}

svg {
  height: 32px;
  width: 32px;
  display: block;

  &.add {
    fill: none;
    stroke: currentcolor;
    stroke-width: 2;
    overflow: visible;
  }

  &.copy {
    fill: currentcolor;
  }
}

@media screen and (min-width: 768px) {
}
</style>


<script>
import Publish from "./Publish.vue";

export default {
  data() {
    return {
      houseSources: [
        {
          navigation: "/eric",
          img: "https://fakeimg.pl/400x400/#ff00aa",
          title: "測試一",
        },
        {
          navigation: "/eric",
          img: "https://a0.muscache.com/pictures/893cb7b3-6902-4c92-b136-235afe5511da.jpg",
          title:
            "測試二 我的名字超幹報長窩窩窩窩窩窩喔窩窩窩窩窩窩窩窩窩窩窩喔窩窩窩屋窩窩窩窩屋窩喔屋窩窩窩窩窩窩屋窩窩窩屋窩屋喔ㄨㄛ",
        },
        {
          navigation: "/eric",
          img: "https://a0.muscache.com/pictures/893cb7b3-6902-4c92-b136-235afe5511da.jpg",
          title:
            "測試三 我也很長 aaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaa",
        },
      ],
      newHouse: {
        navigation: "/eric",
        img: "",
        title: "建立新房源",
      },
      copyHouse: {
        img: "",
        title: "複製新房源",
      },
      nav: "/eric",
    };
  },

  components: {
    Publish,
  },
};
</script>