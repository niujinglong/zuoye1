<template>
<div>
<el-tree
  ref="menuTree"
  :data="data"
  show-checkbox
  node-key="value"
  :default-expand-all="true"
  :default-expanded-keys="[2, 3]"
  :default-checked-keys="[5]"
  :props="defaultProps">
</el-tree>
<el-button @click="getdata">查看信息</el-button>
</div>
</template>
<script>
  export default {
    data() {
      return {
        data: [],
        defaultProps: {
          value: 'value',
          label: 'label'
        }
      };
    },
    created(){
        this.$axios.get('https://localhost:44340/api/VUE/GetList')
        .then(res =>{
            var reg = new RegExp('\\,"children":\\[]',"g");
        this.data = JSON.parse(JSON.stringify(res.data).replace(reg,""));
        })
     },
     methods:{
      getdata(){
        var list = this.$refs["menuTree"].getCheckedNodes(true,true).map(m => m.value);
      }
     }
  }
</script>