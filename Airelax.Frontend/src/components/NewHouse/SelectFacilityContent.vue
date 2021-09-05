<template>
  <div class="contain">
    <div>
      <SelectFacilityPart
          :title="'房源是否設有任何獨特的設備與服務？'"
          :facilities="uniqueFacilities"
          @selected="selected"
      ></SelectFacilityPart>
    </div>
    <div>
      <SelectFacilityPart
          :title="'這些最受旅客歡迎的設備與服務呢？'"
          :facilities="popularFacilities"
          @selected="selected"
      ></SelectFacilityPart>
    </div>
    <div>
      <SelectFacilityPart
          :title="'是否備有以下保安設備？'"
          :facilities="safetyFacilities"
          @selected="selected"
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
  created() {
    this.$store.commit('setNewHouseNextAvailable', true);
    this.next();
  },
  data() {
    return {
      safetyFacilities: setting.facilities.filter((x) => x.tag === safety),
      uniqueFacilities: setting.facilities.filter((x) => x.tag === unique),
      popularFacilities: setting.facilities.filter((x) => x.tag === popular),
      facilityMappingMap: new Map()
    };
  },
  components: {
    SelectFacilityPart,
  },
  methods: {
    selected: function (tag, facilityMappings) {
      this.facilityMappingMap.set(tag, facilityMappings);
      this.next();
    },
    next: function () {
      const facilities = [...this.facilityMappingMap.values()].flatMap(x => x);
      const houseId = this.$route.params.id;
      const req = {
        method: "PUT",
        url: `/${houseId}/facilities`,
        redirectName: `HousePrice`,
        body: {
          ProvideFacilities: facilities,
        }
      }
      this.$store.commit('setNewHouseRequest', req);
    }
  }
}
</script>