
<template>
    <div>
      <h1>Product List</h1>
      <nav aria-label="Page navigation">
        
        <ul class="pagination  justify-content-end">
         
          <li class="page-item">
            <div class="input-group mb-3">
              <label class="input-group-text" for="inputGroupSelect01">Page Size</label>
              <select v-model="pageSize" class="form-select"  @change="changePageSize(pageSize)">
                <option :value="1">1</option>
                <option :value="2">2</option>
                <option :value="3">3</option>
                <option :value="10">10</option>
              </select>
            </div>
          </li>
          <li class="page-item" v-if="apiData.pageIndex > 1" @click.prevent="changePage(apiData.pageIndex-1)"><a class="page-link" href="#">Previous</a></li>
          <li class="page-item" :class="{ active: apiData.pageIndex == n}"  v-for="n in apiData.totalPages" :key="n" @click.prevent="changePage(n)">
            <span v-if="apiData.pageIndex == n" class="page-link">{{ n }}</span>
            <a v-else class="page-link" href>{{ n }}</a>
          </li>
          <li class="page-item" v-if="apiData.totalPages > apiData.pageIndex" @click.prevent="changePage(apiData.pageIndex+1)"><a class="page-link" href="#">Next</a></li>
        </ul>
      </nav>
      <table class="table">
        <thead>
          <tr>
            <th scope="col">ID</th>
            <th scope="col">Name</th>
            <th scope="col">Description</th>
            <th scope="col">Released</th>
            <th scope="col">Create Date</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in apiData.items" :key="item.id">
            <th scope="row">{{ item.id }}</th>
            <td>{{ item.name }}</td>
            <td>{{ item.description }}</td>
            <td><div class="form-check form-switch">
                <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckChecked" :checked="item.isRelease" disabled>
              </div>
            </td>
            <td>{{ this.$formatDate(item.createDate,'MM/DD/YYYY') }}</td>
          </tr>
        </tbody>
      </table>
      <div>
        
      <nav aria-label="Page navigation">
        <ul class="pagination justify-content-end">
          <li class="page-item">
            <div class="input-group mb-3">
              <label class="input-group-text" for="inputGroupSelect01">Page Size</label>
              <select v-model="pageSize" class="form-select"  @change="changePageSize(pageSize)">
                <option :value="1">1</option>
                <option :value="2">2</option>
                <option :value="3">3</option>
                <option :value="10">10</option>
              </select>
            </div>
          
          </li>
          <li class="page-item" v-if="apiData.pageIndex > 1" @click.prevent="changePage(apiData.pageIndex-1)"><a class="page-link" href="#">Previous</a></li>
          <li class="page-item" :class="{ active: apiData.pageIndex == n}"  v-for="n in apiData.totalPages" :key="n" @click.prevent="changePage(n)">
            <span v-if="apiData.pageIndex == n" class="page-link">{{ n }}</span>
            <a v-else class="page-link" href>{{ n }}</a>
          </li>
          <li class="page-item" v-if="apiData.totalPages > apiData.pageIndex" @click.prevent="changePage(apiData.pageIndex+1)"><a class="page-link" href="#">Next</a></li>
        </ul>
      </nav>
      </div>
    </div>
</template>
<script>
import axios from 'axios';
import { ref } from 'vue'

var query = { "orderBy": "id", "isDesc": false, "pageIndex": 1,"pageSize": 1 };
export default {
  setup() {
    const pageSize = ref(1)
    return { pageSize }
  },
  data() {
    return { 
      apiData: [],
    };
  },
  mounted(){
    this.fetchData();
  },
  methods: {
    fetchData() {
      axios.post('http://localhost/api/Product/QueryProducts',query)
        .then(response => {
          console.log(response.data);
          const data = response.data;
          this.apiData = data.data;
        })
        .catch(error => {
          console.error(error);
        });
    },
    changePage(goToPage) {
      if (goToPage === query.pageIndex) return;
      query.pageIndex = goToPage;
      this.fetchData();
    },
    changePageSize(size) {
      query.pageSize = size;
      console.log(query);
      this.fetchData();
    },
  }
}
</script>