<template>
  <div v-if="comment" class="my-container">
    <div class="summary">
      <CommentSummary :rank="rank" :comment="comment"></CommentSummary>
    </div>
    <div class="sum-char container-fluid">
      <div class="row">
        <Comments :rank="rank"></Comments>
      </div>
    </div>
    <div class="scrollbar container-fluid">
      <Messages :com="comment"></Messages>
    </div>
  </div>
  <div class="btn-box">
    <button class="btn-modal" v-if="comment" @click="show" data-bs-toggle="modal" data-bs-target="#myModal">
      顯示全部{{ comment.length }}則評價
    </button>
  </div>
</template>

<script>
import Messages from "./Comment/Messages.vue";
import Comments from "./Comment/Comments.vue";
import CommentSummary from "./Comment/CommentSummary.vue";
export default {
  components: {
    Messages,
    Comments,
    CommentSummary,
  },
  methods:{
      show(){
          this.$emit('Show',true)
      }
  },
  props:["comment","rank"]
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
    height: 816px;
    display: block;
    margin-top: 32px;
    overflow: hidden;
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
    height: 408px;
    display: flex;
    flex-wrap: wrap;
  }
}
</style>