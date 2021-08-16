<template>
  <Navbar></Navbar> 
  
  <main>
    <div class="album py-5 bg-light">
      <div class="container">
        <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">

          <div class="col" v-for="item in data" :key="item.id">
            <div class="card shadow-sm">
              <div class="pic"><img :src="item.picture[0]" class="w-100"></div>
              <div class="card-body">
                <p class="card-text">{{item.Title}}</p>
                <div class="d-flex justify-content-between align-items-center">
                  <div class="btn-group">
                    <button type="button" class="btn btn-sm btn-outline-secondary">View</button>
                    <button type="button" class="btn btn-sm btn-outline-secondary">Edit</button>
                  </div>
                  <small class="text-muted">9 mins</small>
                </div>
              </div>
            </div>
          </div>

        </div>
      </div>
    </div>
  </main>

  <Footer></Footer>
</template>

<script>
import axios from 'axios';
import Navbar from '@/components/Navbar.vue'
import Footer from '@/components/Footer.vue'

export default {
  data(){
    return{
      data: []
    }
  },
  mounted:function(){
    const api = 'https://bs-howard.github.io/Homework/fake-search-data.json';
    axios.get(api)
      .then(response => {
        this.data = response.data
    })
    .catch( error => {
        console.log(error);
    })
  },
  components: {
    Navbar,
    Footer
  }
}
</script>
