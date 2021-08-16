<template>
  <div class="container-fluid">
    <div class="row">
      <div class="summary col-12 col-lg-4 d-flex">
        <CommentSummary :data="data"></CommentSummary>
      </div>
      <div class="search col-12 col-lg-8 ">
        <div class="icon"></div>
        <input type="text" placeholder="搜尋評價" />
      </div>
      <div class="row ranks col-12 col-lg-4">
        <div
          class="rank col-12 col-md-6 col-lg-12"
          v-for="(item, key, index) in data.rank"
          :key="index"
          v-show="key !== 'star'"
        >
          <Rank
            :chineseName="setting.find((x) => x.eng === key).ch"
            :value="item"
          ></Rank>
        </div>
      </div>
      <div class="row messages col-12 col-lg-8 ps-md-5">
        <div class="row">
          <div
            v-for="comment in data.comments"
            :key="comment.id"
            class="message"
          >
            <Message :msg="comment"></Message>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.summary {
  margin-bottom: 15px;
}
.search {
  background-color: rgb(247, 247, 247);
  font-size: 14px;
  font-weight: 600;
  color: #222;
  padding: 11px;
  border: 1px solid rgb(176, 176, 176);
  border-radius: 44px;
  display: flex;
  margin-bottom: 24px;

  &:focus-within {
    padding: 10px;
    border: 2px solid #222;
    border-radius: 44px;
  }
  input {
    background-color: rgb(247, 247, 247);
    font-weight: 400;
    color: rgb(34, 34, 34);
    border: none;
    outline: none;
    width: 100%;
    height: 20px;
  }

  .icon {
    width: 13px;
    height: 13px;
    border: 1px solid #222;
    border-radius: 100%;
    margin: 0 12px 0 6px;
    &::before {
      content: "";
      display: flex;
      width: 6px;
      height: 1px;
      background-color: #222;
      transform: rotate(45deg);
      position: relative;
      top: 12px;
      left: 9px;
    }
  }
}

.ranks {
  margin-bottom: 32px;
  .rank {
    font-size: 14px;
    margin-bottom: 12px;
  }
}

.messages {
  .message {
    margin-bottom: 32px;
  }
}

@media screen and (min-width: 768px) {
  .ranks {
    height: 250px;
  }
  .row{
      margin-right: 0 !important;
  }
  .search{
    margin-left: 3rem;
    width: 60%;
  }
}
</style>

<script>
import CommentSummary from "./Comment/CommentSummary";
import setting from "./Comment/msgSetting";
import Rank from "./Comment/Rank.vue";
import Message from "./Comment/Message.vue";
import axios from "axios";
export default {
  components: {
    CommentSummary,
    Rank,
    Message,
  },
  data() {
    return {
      setting: setting.chineseTranslation,
      data: [],
    };
  },
  created: function () {
    const api = "https://bs-howard.github.io/Homework/fake-room-data.json";
    axios
      .get(api)
      .then((response) => {
        this.data = response.data;
      })
      .catch((error) => {
        console.log(error);
      });
  },
};
</script>