<template>
  <Layout :title="'選擇房間圖片'">
    <div class="container">
      <div class="upload">
        <h2>所有相片</h2>
        <label class="btn border-dark fw-bolder">
          <input id="upload_img" style="display:none;" type="file" @change="photoChange">上傳相片
        </label>
        <div class="row" id="showPhoto">
          <div class="col-12 col-md-6" v-for="(photo,index) in photos" :key="index">
            <img class="photo" :src="photo" alt="">
          </div>
        </div>
        <label id="uploadDiv" for="upload_img">
          <img src="@/assets/pic/upload.svg">
          <p>新增更多</p>
        </label>
      </div>
    </div>
  </Layout>
</template>

<script>
import Layout from "../../components/NewHouse/Layout.vue";
import axios from "axios";

export default {
  name: "Photos",
  components: {
    Layout
  },
  data() {
    return {
      photos: []
    }
  },
  methods: {
    photoChange(e) {
      if (!e.target.files || !e.target.files[0]) return;
      const file = e.target.files[0];
      this.send3rd(file);
    },
    send3rd(file) {
      const fileUploadUrl = 'https://api.cloudinary.com/v1_1/dq5jyb6g8/image/upload';
      const formData = new FormData();
      formData.append("file", file);
      formData.append("upload_preset", "dsojvh87");
      const vm = this;
      axios({
        url: fileUploadUrl,
        method: 'Post',
        data: formData,
        headers: {"Content-Type": "multipart/form-data"}
      }).then(res => {
        const p = Array.from(vm.photos);
        p.push(res.data.secure_url);
        vm.photos = p;
      }).catch(err => console.log(err));
    }
  },
  created() {
    const houseId = this.$route.params.id;
    if (houseId) {
      this.$store.commit('setNewHouseNextAvailable', false);
      return;
    }
    this.$store.commit('setNewHouseNextAvailable', true);
  },
  watch: {
    photos(val) {
      if (val.length >= 5) {
        this.$store.commit('setNewHouseNextAvailable', true);
        const houseId = this.$route.params.id;
        const req = {
          method: houseId ? "PUT" : "POST",
          url: houseId ? `/${houseId}/pictures` : "",
          redirectName: `HouseTitle`,
          body: {
            Images: this.photos
          }
        }
        this.$store.commit('setNewHouseRequest', req);
      } else
        this.$store.commit('setNewHouseNextAvailable', false);
    }
  },
}
</script>

<style scoped>
.photo {
  max-height: 200px;
}

.col-12.col-md-6 {
  padding: 8px;
  margin-bottom: 16px;
  border: 1px #ccc solid;
}
</style>