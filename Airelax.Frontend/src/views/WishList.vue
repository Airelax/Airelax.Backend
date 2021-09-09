<template>
  <div class="row top content">
      <div class="col-md-6 col-12 position-relative houses">
        <div class="back">
          <a href="/"><img src="@/assets/image/Room/icon/back.svg"/></a>
          <div class="date">
            <a
              href="#"
              data-bs-toggle="offcanvas"
              data-bs-target="#offcanvasBottom"
              aria-controls="offcanvasBottom"
            >
            <img src="@/assets/image/Room/icon/setting.svg"/>
            </a>
          </div>
        </div>
        <div class="px-4 pt-md-3">
        </div>
        <div class="Result">
          <div class="col-12" v-if="false && get">
          <BrowsingRecord :rooms="rooms" :nightCount="nightCount">
          </BrowsingRecord>
          </div>
        </div>
      </div>
    <div class="col-6 map"></div>
  </div>
</template>

<script>
import axios from "axios";
import BrowsingRecord from "../components/Search/BrowsingRecord";
export default {
  created() {
    axios
        .get(`/api/WishLists/wishList?wishId=${this.$route.params.id}`, {
          headers: {
            "Access-Control-Allow-Origin": "*",
          },
        })
        .then((res) => {
          const data = res.data;
          this.rooms = data.houses;
          // this.getPicture();
          this.$store.state.rooms = {};
          console.log(res.data)
          this.get = true;
        });
  },
  // getPicture() {
  //   this.rooms.forEach(item => {
  //     if (item.picture.length !== 0) return;
  //     this.getRandomList(0, this.setting.pictures.length - 1, this.getRandomNumber(5, this.setting.pictures.length - 1)).forEach(x => {
  //       item.picture.push(this.setting.pictures[x]);
  //     })
  //   });
  // },
  components: {
    BrowsingRecord,
  },
  data() {
    return {
      wishLists: null,
      isWishListGet : false,
      rooms : Array,
      nightCount : 3,
    };
  },
};
</script>

<style scoped lang="scss">
.houses.position-relative,
.map {
  height: calc(100vh - 100px);
}

.back {
  width: 100%;
  top: 0;
  left: 0;
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1.5rem;
  background-color: transparent;
  z-index: 100;

  &.fixed {
    position: fixed;
  }

  a {
    display: flex;
  }

  img {
    width: 1.2rem;
    cursor: pointer;
    margin: auto;
  }

  .date {
    display: flex;
  }

  .between {
    margin: 0 0.5rem;
  }
}

.btn-dark {
  border-radius: 8px;
}

.position-relative {
  padding: 0;
}

.record {
  background-color: #f7f7f7;
}

.text-start {
  p {
    font-size: 0.9rem;
  }

  h4 {
    font-size: 1.5em;
    font-weight: 700;
    margin: 1rem 0;
  }
}

.type_place {
  p {
    color: rgb(150, 150, 150);
  }
}

.onlybtn {
  .checkbtn {
    font-size: 30px;
    margin: 20px 20px -10px 5px;
    line-height: 10;
    background-color: #ccc;
    border-color: #ccc;
    box-shadow: 3px 3px 5px #fff;

    &:checked {
      background-color: #717171;
      border-color: #717171;
      box-shadow: 3px 3px 5px #cccccc;
    }
  }

  .bed {
    .btn_ {
      width: 40px;
      height: 40px;
      background: transparent;
      border: 1px solid #717171;
      font-size: 25px;
      font-weight: bolder;
      color: #717171;
      margin-right: 20px;
    }

    .btnAdd {
      width: 40px;
      height: 40px;
      background: transparent;
      border: 1px solid #717171;
      font-size: 15px;
      font-weight: bolder;
      color: #717171;
      margin-left: 20px;
    }
  }
}

@media screen and (min-width: 768px) {
  .fake {
    height: 40rem;
    object-fit: cover;
  }
  .top {
    margin-right: 0 !important;
    margin-top: 90px;
  }
  .Result {
    .col-12 {
      background-color: #f7f7f7;
    }
  }
  .record {
    padding-left: 2rem;
  }
  .position-relative {
    padding: 0;
    overflow: auto;
    height: 40rem;

    &::-webkit-scrollbar {
      display: none;
    }
  }
  .text-start {
    margin: 0 !important;
  }
  .onlybtn {
    display: none;
  }

  .filters {
    font-size: 14px;
    line-height: 18px;
    margin-right: 10px;
    padding: 10px 20px !important;

    &:hover {
      border: 1px solid #222222 !important;
    }

    &:active,
    &:checked {
      border: 2px solid #222222 !important;
    }
  }
  .dropdown-menu {
    border-radius: 16px;

    p {
      color: #717171;
      font-size: 14px;
      padding: 10px 30px;
    }

    h5 {
      padding: 15px 0 0 30px;
    }

    .checkbtn {
      font-size: 30px;
      margin: 20px 20px -10px 5px;
      line-height: 10;
      background-color: #ccc;
      border-color: #ccc;
      box-shadow: 3px 3px 5px #fff;

      &:checked {
        background-color: #717171;
        border-color: #717171;
        box-shadow: 3px 3px 5px #cccccc;
      }
    }

    .type_place {
      padding: 20px 15px 10px 30px;

      h6 {
        margin-top: 10px;
        padding-left: 30px;
      }
    }
  }
  .more {
    .btn_ {
      width: 40px;
      height: 40px;
      background: transparent;
      border: 1px solid #717171;
      font-size: 25px;
      font-weight: bolder;
      color: #717171;
      margin-right: 20px;
      margin-bottom: 15px;
    }

    .btnAdd {
      width: 40px;
      height: 40px;
      background: transparent;
      border: 1px solid #717171;
      font-size: 20px;
      font-weight: bolder;
      color: #717171;
      margin-left: 20px;
      margin-bottom: 12px;
    }

    .moreOptions {
      h5 {
        font-size: 16px;
        margin-bottom: 2px;
        margin-top: 15px;
      }

      p {
        margin-bottom: 2px;
        font-size: 14px;
        color: #717171;
      }

      a {
        font-size: 14px;
      }

      .checkbtn {
        font-size: 30px;
        margin: 20px 20px -10px 5px;
        line-height: 10;
        background-color: #ccc;
        border-color: #ccc;
        box-shadow: 3px 3px 5px #fff;
        top: 410px;
        right: 100px;

        &:checked {
          background-color: #717171;
          border-color: #717171;
          box-shadow: 3px 3px 5px #cccccc;
        }
      }
    }
  }
}
</style>
