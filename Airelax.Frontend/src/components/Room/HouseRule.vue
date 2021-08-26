<template>
  <div class="main">
    <h2>《房屋守則》</h2>
    <ul>
      <li>
        <img src="@/assets/image/Room/icon/time.svg" />入住時間：下午{{
          detail.checkinTime.split("-")[0]
        }}後
      </li>
      <li>
        <img src="@/assets/image/Room/icon/time.svg" />退房時間：上午{{
          detail.checkinTime.split("-")[1]
        }}
      </li>
      <li><img src="@/assets/image/Room/icon/smoke.svg" />禁止吸煙</li>
      <li><img src="@/assets/image/Room/icon/pet.svg" />不允許攜帶寵物</li>
      <li>
        <img src="@/assets/image/Room/icon/gather.svg" />不允許舉辦聚會和活動
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  props: ["detail"],
};
</script>

<style lang="scss" scoped>
.main {
  text-align: left;
  margin: 0 1.5rem;
  h2 {
    font-size: 2rem;
  }
  ul {
    li {
      margin: 2rem 0;
      display: flex;
      align-items: center;
      img {
        width: 1.3rem;
        margin-right: 1rem;
      }
    }
  }
}
@media screen and (min-width: 768px) {
  .main {
    h2 {
      display: none;
    }
    ul {
      li {
        margin: 1rem 0;
        &:first-child {
          margin-top: 0;
        }
        img {
          width: 1.2rem;
          margin-right: 1rem;
        }
      }
    }
  }
}
</style>