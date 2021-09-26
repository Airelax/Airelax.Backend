<template>
  <div class="user">
    <img :src="msg.cover" style="width: 3rem;"/>
    <div class="item">
      <span v-html="highlight(msg.name)"></span>
      <span v-html="highlight(msg.date)"></span>
    </div>
  </div>
  <div :class="{ massage: !isModal }">
    <p v-html="highlight(msg.content)"></p>
  </div>
</template>


<style lang="scss" scoped>
.user {
  display: flex;
  margin-bottom: 12px;
  align-items: center;
}

.user img {
  width: 45px;
  height: 45px;
  border-radius: 50%;
}

.item {
  padding-left: 12px;
  display: flex;
  flex-direction: column;
  text-align: start;
}

.item > span:nth-child(1) {
  font-size: 16px;
  font-weight: 600;
  margin-bottom: 0.2rem;
}

.item > span:nth-child(2) {
  color: #717171;
  font-size: 14px;
  margin-top: 0.2rem;
}

.massage {
  display: -webkit-box;
  text-align: initial;
  -webkit-line-clamp: 2;
  -webkit-box-orient: vertical;
  overflow: hidden;
}

.massage p {
  text-align: justify;
  margin-bottom: 0;
  line-height: 1.5rem;
}

@media screen and (min-width: 768px) {
  .item {
    margin: auto 0;
  }
}

@media screen and (min-width: 1200px) {
  .user {
    margin-bottom: 16px;
  }
}
</style>

<script>
export default {
  props: {
    msg: { type: Object },
    search: { type: String },
    isModal: { type: Boolean, default: false },
  },
  methods: {
    highlight(text) {
      if (this.search == undefined) return text;
      let regWord = new RegExp(this.search, "gi");
      return text.replace(
        regWord,
        `<span style="background: orange;">${this.search}</span>`
      );
    },
  },
};
</script>