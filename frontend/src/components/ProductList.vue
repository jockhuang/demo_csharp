
<template>
    <div>
      <h1>Product List</h1>

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
      <DemoPagination :pageIndex="queryConfig.pageIndex" :pageSize="queryConfig.pageSize" :totalPages="apiData.totalPages" @change-page-config="changePageConfig"/>
    </div>
</template>
<script>
import axios from 'axios';
import DemoPagination from "./Pagination.vue";

export default {
  name: "DemoProductList",
  components: {
    DemoPagination
  },

  data() {
    return { 
      queryConfig: { "orderBy": "id", "isDesc": false, "pageIndex": 1,"pageSize": 2 },
      apiData: [],
      
    };
  },
  mounted(){
    this.fetchData();
  },
  methods: {
    fetchData() {
      axios.post('http://localhost/api/Product/QueryProducts',this.queryConfig)
        .then(response => {
          console.log(response.data);
          const data = response.data;
          this.apiData = data.data;
        })
        .catch(error => {
          console.error(error);
        });
    },
    changePageConfig(newPageIndex,newPageSize) {
      this.queryConfig.pageIndex =newPageIndex;
      this.queryConfig.pageSize = newPageSize;
      this.fetchData();
    }
 
  }
}
</script>