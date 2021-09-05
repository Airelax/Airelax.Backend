<template>
  <div class="main">
    <h2>《房屋守則》</h2>
    <ul>
      <li>
        <img src="@/assets/image/Room/icon/time.svg" />入住時間：下午{{
          detail.checkinTime
        }}後
      </li>
      <li>
        <img src="@/assets/image/Room/icon/time.svg" />退房時間：上午{{
          detail.checkoutTime
        }}前
      </li>
      <li v-if="!detail.allowBaby || !detail.allowChild"><img src="@/assets/pic/HouseRulesIcons/noKid.svg" />不適合兒童和嬰幼兒</li>
      <li v-if="detail.allowPet"><img src="@/assets/pic/HouseRulesIcons/pet.svg" />允許攜帶寵物</li>
      <li v-if="!detail.allowPet"><img src="@/assets/image/Room/icon/pet.svg" />不允許攜帶寵物</li>
      <li v-if="!detail.allowParty"><img src="@/assets/pic/HouseRulesIcons/noEvent.svg" />不允許舉辦聚會和活動</li>
      <li v-if="!detail.allowSmoke"><img src="@/assets/image/Room/icon/smoke.svg" />禁止吸煙</li>
      <li v-if="detail.other!=null" class="d-block">
        <p class="mb-3">其他注意事項:</p>
        <span style="line-height:1.5rem; font-size: 0.9rem;">{{detail.other}}</span>
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
    font-weight: 700;
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