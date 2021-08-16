<template>
  <div v-if="data" class="my-container">
    <div class="summary">
      <CommentSummary :v-if="data" :data="data"></CommentSummary>
    </div>
    <div class="sum-char container-fluid">
      <div class="row">
        <Comment :rank="data.rank"></Comment>
      </div>
    </div>
    <div class="scrollbar container-fluid">
      <Message :com="data.comments"></Message>
    </div>
  </div>
  <div class="btn-box">
    <button class="btn-modal" v-if="data.comments" @click="show" data-bs-toggle="modal" data-bs-target="#myModal">
      顯示全部{{ data.comments.length }}則評價
    </button>
  </div>
</template>

<script>
import Message from "./Comment/Messages.vue";
import Comment from "./Comment/Comments.vue";
import CommentSummary from "./Comment/CommentSummary.vue";
import axios from "axios";
export default {
  components: {
    Message,
    Comment,
    CommentSummary,
  },
  data() {
    return {
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
  methods:{
      show(){
          this.$emit('Show',true)
      }
  }
};
</script>

<style scoped>


.row {
  width: 100%;
}

.my-container * {
  font-family: Circular, -apple-system, BlinkMacSystemFont, Roboto,
    "Helvetica Neue", sans-serif;
  color: #222;
}
.my-container {
  overflow: auto;
  padding: 32px 0 24px;
  position: relative;
}
.my-container::-webkit-scrollbar {
  display: none;
}
.summary {
  margin-bottom: 32px;
  position: absolute;
  top: 1rem;
  left: 0;
}
.sum-char {
  display: none;
}
.scrollbar {
  width: fit-content;
  display: flex;
}
.btn-box {
  border-bottom: 1px solid rgb(221, 221, 221);
}
.btn-modal {
  width: 100%;
  height: 48px;
  font-weight: 600;
  background-color: transparent;
  border: 1px solid #222;
  border-radius: 8px;
  margin-bottom: 24px;
  animation: AnimEnds 0.125s;
}
/* .btn-modal:focus {
  background-color: #f7f7f7;
  text-decoration: underline;
  animation: AnimStarts 0.125s;
  animation-fill-mode: forwards;
} */

.container-fluid {
  padding: 0;
  padding-top: 2rem;
}
@keyframes AnimStarts {
  0% {
    width: 100%;
    height: 48px;
    font-size: 16px;
    margin-top: 0;
    margin-bottom: 24px;
  }
  100% {
    width: 95%;
    height: 44px;
    font-size: 14px;
    margin-top: 2px;
    margin-bottom: 26px;
  }
}
@keyframes AnimEnds {
  0% {
    width: 95%;
    height: 44px;
    font-size: 14px;
    margin-top: 2px;
    margin-bottom: 26px;
  }
  100% {
    width: 100%;
    height: 48px;
    font-size: 16px;
    margin-top: 0;
    margin-bottom: 24px;
  }
}
@media screen and (min-width: 768px) {
  .sum-char {
    width: 100%;
    display: flex;
  }
  .scrollbar {
    width: 100%;
    display: block;
    margin-top: 32px;
  }
  .btn-modal {
    width: 169px;
    display: block;
  }
  @keyframes AnimStarts {
    0% {
      width: 169px;
      height: 48px;
      font-size: 16px;
      margin-top: 0;
      margin-bottom: 24px;
      margin-left: 0;
    }
    100% {
      width: 163px;
      height: 44px;
      font-size: 15px;
      margin-top: 2px;
      margin-bottom: 26px;
      margin-left: 3px;
    }
  }
  @keyframes AnimEnds {
    0% {
      width: 163px;
      height: 44px;
      font-size: 15px;
      margin-top: 2px;
      margin-bottom: 26px;
      margin-left: 3px;
    }
    100% {
      width: 169px;
      height: 48px;
      font-size: 16px;
      margin-top: 0;
      margin-bottom: 24px;
      margin-left: 0;
    }
  }
}
@media screen and (min-width: 1200px) {
  .scrollbar {
    display: flex;
    flex-wrap: wrap;
  }
}
</style>