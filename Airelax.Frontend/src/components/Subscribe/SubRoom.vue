<template>
  <div class="row room">
    <div class="col-3">
      <img :src="room.pictures[0]" />
    </div>
    <div class="col-9">
      <div class="typeAddress">在{{ room.Location.Town }}的{整套公寓}</div>
      <div class="title">
        {{ room.title }}
      </div>
      <div class="space">
        <span>{{ room.Space.Bed }}張床 · </span>
        <span>{{ room.Space.Bathroom }}間衛浴</span>
      </div>
      <div class="comment">
        <Star></Star>
        <span class="starScore" id="starScore"> {{ room.rank.star }} </span>
        <span class="commentCount" id="commentCount"
          >({{ room.comments.length }})</span
        >
      </div>
    </div>
  </div>
</template>
<style lang="scss" scoped>
.room {
  .col-3 {
    display: flex;
    justify-content: center;
    align-items: center;
    img {
      width: 90px;
      height: 90px;
      border-radius: 20px;
    }
  }
  .col-9 {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    color: #000;
    padding: 0 20px;
    font-weight: 300;
    font-size: 14px;
    .typeAddress {
      font-size: 10px;
    }
    .title {
      overflow: hidden;
    }
    .space {
      font-size: 12px;
      color: #666666;
    }
    .comment {
      display: flex;
      font-size: 12px;
      .starScore {
        font-weight: 500;
        padding: 0 3px;
      }
    }
  }
}
@media screen and(min-width:768px) {
  .room {
    padding: 0 0 20px;
  }
}
</style>
<script>
import Star from "../Search/Star.vue";
export default {
  components: {
    Star,
  },
  props: {
    room: {
      type: Object,
    },
    nightCount: {
      type: Number,
    },
  },
};
</script>