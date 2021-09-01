<template>
  <div id="map">{{ location }}</div>
</template>

<script>
import { Loader } from "@googlemaps/js-api-loader";

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
    console.log(this.location);
    this.initMap();
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

<style scoped>
#map {
  width: 100%;
  height: 100%;
}
</style>