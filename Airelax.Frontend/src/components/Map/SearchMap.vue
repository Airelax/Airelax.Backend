<template>
  <div id="map"></div>

</template>

<script>
import {Loader} from "@googlemaps/js-api-loader";
import createHTMLMapMarker from "@/components/Map/PriceMarker";

export default {
  name: "SearchMap",
  props: {
    location: {
      type: Object,
    },
    houses: {
      type: Array,
    },
  },
  data() {
    return {
      map: null,
      loader: new Loader({
        apiKey: "AIzaSyCGLEnb08NgQjz7o7Fo8a93ew3-ecouExk",
        version: "weekly",
      }),
    };
  },
  mounted() {
    this.initMap();
  }, beforeUpdate() {
  },
  methods: {
    initMap() {
      this.loader.load().then(() => {
        this.map = new window.google.maps.Map(document.querySelector("#map"), {
          center: {
            lat: this.location.center.latitude,
            lng: this.location.center.longitude,
          },
          zoom: 12,
          minZoom: 3,
          maxZoom: 20,
          mapTypeControl: false,
        });

        this.houses.forEach(house => {
          const marker = createHTMLMapMarker({
            latlng: new window.google.maps.LatLng(house.coordinate.latitude, house.coordinate.longitude),
            map: this.map,
            html: `<div class="badge rounded-pill bg-light text-dark p-1" style="z-index:999;">NT$${house.price.origin}TWD</div>`
          });

          marker.addListener("click", () => {
            alert("Partyin Partyin Yeah!");
          });
        });
        this.setMarker();

      });
    },
    setMarker() {
      new window.google.maps.Marker({
        position: {
          lat: this.location.center.latitude,
          lng: this.location.center.longitude,
        },
        map: this.map,
      });
    },
  },
};
</script>

<style lang="scss" scoped>
#map {
  width: 100%;
  height: 100%;
}

html,
body {
  height: 100%;
  margin: 0;
  padding: 0;
}

</style>