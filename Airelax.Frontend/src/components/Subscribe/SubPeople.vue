<template>
  <div class="people">
    <div class="people-control">
      <div class="txt">
        <strong>成人</strong>
        <span>滿13歲</span>
      </div>
      <div>
        <button class="minus" @click="minus" id="adult-minus">-</button
        ><span id="adult">{{ adult }}</span
        ><button class="plus" @click="plus" id="adult-plus">+</button>
      </div>
    </div>
    <div class="people-control" id="child">
      <div class="txt">
        <strong>兒童</strong>
        <span>2 - 12歲</span>
      </div>
      <div>
        <button class="minus" @click="minus" id="child-minus">-</button
        ><span>{{ child }}</span
        ><button class="plus" @click="plus" id="child-plus">+</button>
      </div>
    </div>
    <div class="people-control" id="toddler">
      <div class="txt">
        <strong>嬰幼兒</strong>
        <span>2歲以下</span>
      </div>
      <div>
        <button class="minus" @click="minus" id="toddler-minus">-</button
        ><span>{{ toddler }}</span
        ><button class="plus" @click="plus" id="toddler-plus">+</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  methods: {
    plus(e) {
      if (e.target.getAttribute("id") == "adult-plus")
        this.$store.state.adult += 1;
      else if (e.target.getAttribute("id") == "child-plus")
        this.$store.state.child += 1;
      else if (e.target.getAttribute("id") == "toddler-plus")
        this.$store.state.toddler += 1;
    },
    minus(e) {
      if (e.target.getAttribute("id") == "adult-minus")
        this.$store.state.adult -= 1;
      else if (e.target.getAttribute("id") == "child-minus")
        this.$store.state.child -= 1;
      else if (e.target.getAttribute("id") == "toddler-minus")
        this.$store.state.toddler -= 1;
    },
  },
  computed: {
    adult() {
      return this.$store.state.adult;
    },
    child() {
      return this.$store.state.child;
    },
    toddler() {
      return this.$store.state.toddler;
    },
  },
  watch: {
    adult(val) {
      if (val <= 0) {
        this.$store.state.adult = 0;
        this.$store.state.child = 0;
        this.$store.state.toddler = 0;
      }
    },
    child(val) {
      if (val < 0 || this.$store.state.adult === 0) this.$store.state.child = 0;
    },
    toddler(val) {
      if (val < 0 || this.$store.state.adult === 0)
        this.$store.state.toddler = 0;
    },
  },
};
</script>

<style lang="scss" scoped>
.people {
  display: flex;
  flex-direction: column;
  .people-control {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 1.2rem 0;
    &:not(:last-child) {
      border-bottom: 1px solid rgb(204, 201, 201);
    }
    margin: 0.3rem 2rem;
    .txt {
      display: flex;
      flex-direction: column;
      line-height: 1.2rem;
      strong {
        font-size: 1.2rem;
      }
      span {
        color: rgb(104, 102, 102);
        font-size: 0.9rem;
      }
    }
    button {
      width: 2rem;
      height: 2rem;
      margin: 0 0.8rem;
      border-radius: 50%;
      background-color: #fff;
      border: 1px solid rgb(204, 201, 201);
      font-size: 1.2rem;
    }
  }
}
</style>