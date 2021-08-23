<template>
  <div class="contain">
    <div>
      <SelectFacilityPart
        :title="'房源是否設有任何獨特的設備與服務？'"
        :facilities="uniqueFacilities"
      ></SelectFacilityPart>
    </div>
    <div>
      <SelectFacilityPart
        :title="'這些最受旅客歡迎的設備與服務呢？'"
        :facilities="popularFacilities"
      ></SelectFacilityPart>
    </div>
    <div>
      <SelectFacilityPart
        :title="'是否備有以下保安設備？'"
        :facilities="safetyFacilities"
      ></SelectFacilityPart>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.contain {
  padding: 30px;

  > div {
    margin-bottom: 30px;
  }
}
</style>

<script>
import SelectFacilityPart from "./SelectFacilityPart.vue";
import setting from "./setting.js";
const unique = "unique";
const popular = "popular";
const safety = "safety";

export default {
  data() {
    return {
      safetyFacilities: setting.facilities.filter((x) => x.tag === safety),
      uniqueFacilities: setting.facilities.filter((x) => x.tag === unique),
      popularFacilities: setting.facilities.filter((x) => x.tag === popular),
    };
  },
  components: {
    SelectFacilityPart,
  },
};
</script>