<template>
  <div class="title">
    <i class="fas fa-star"></i>
    <h2>
      <div v-if="data.rank">
        {{ data.rank.star }}．{{ data.comments.length }}則評價
      </div>
    </h2>
  </div>
</template>


<style lang="scss" scoped>
.title {
  display: flex;
  align-items: baseline;
  align-items: center;
  i{
    color: #FF385C;
    margin-right: 1rem;
  }
  h2 {
    font-size: 22px;
    font-weight: 600;
    text-align: start;
    line-height: 32px;
  }
}
</style>

<script>
export default {
  props: ["data"],
};
</script>