
<template >
    <div>
      <h1>Product List</h1>
      <el-table stripe
        :data="apiData.items"
        :default-sort="{ prop: 'id', order: 'ascending' }"
        @sort-change="changeOrder" 
        style="width: 100%"
      >
        <el-table-column prop="id" label="ID" sortable width="180" />
        <el-table-column prop="name" label="Name" sortable width="180" />
        <el-table-column prop="description" sortable label="Description"  />
        <el-table-column prop="isRelease" label="Released" >

          <template #default="scope">
            <el-switch
              v-model="scope.row.isRelease"
              size="small"
              disabled
            />
            <!-- <el-col :sm="1" :lg="1">
            <el-result :icon="scope.row.isRelease ? 'success' : 'error'" />
            </el-col> -->
          </template>
        </el-table-column>
        <el-table-column prop="createDate" :formatter="formatDemoDate" sortable label="Create Date" />
        <el-table-column label="Operations">
          <template #default="scope">
            <el-button size="small" @click="handleEdit(scope.$index, scope.row)">
              Edit
            </el-button>
            <el-button
              size="small"
              type="danger"
              @click="handleDelete(scope.$index, scope.row)"
            >
              Delete
            </el-button>
          </template>
        </el-table-column>
      </el-table>
      
      <DemoPagination :pageIndex="queryConfig.pageIndex" :pageSize="queryConfig.pageSize" :totalCount="apiData.totalCount" @change-page-config="changePageConfig"/>
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
      queryConfig: { "orderBy": "id", "isDesc": false, "pageIndex": 1,"pageSize": 5 },
      apiData: [],
    };
  },
  mounted(){
    this.fetchData();
  },
  methods: {
    async fetchData() {
      console.log(this.queryConfig);
      await axios.post('http://localhost/api/Product/QueryProducts',this.queryConfig)
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
    },
    changeOrder(orderOp){
      console.log(orderOp);
      this.queryConfig.orderBy = orderOp.prop;
      if(orderOp.order == "descending"){
        this.queryConfig.isDesc = true;
      }else if(orderOp.order == "ascending"){
        this.queryConfig.isDesc = false;
      }else{
        this.queryConfig.isDesc = false;
        this.queryConfig.orderBy="id";
      
      }
        
      this.fetchData();
    },
    formatDemoDate(row, col, value) {
      // Then specify how you want your dates to be formatted
      return this.$formatDate(value,'MM/DD/YYYY');
    },
    handleEdit(index, row){
      console.log("handleEdit",index, row)
    },
    handleDelete (index, row) {
      console.log("handleDelete",index, row)
}
 
  }
}
</script>
