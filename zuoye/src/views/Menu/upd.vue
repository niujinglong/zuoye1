<template>
<div>
<el-form ref="form" :model="form" label-width="80px">
  <el-form-item label="">
      <el-cascader
       v-model="form.ParentId"
    :options="options"
    :props="{ checkStrictly: true }"
    ref="getParentId"
    clearable></el-cascader>
  </el-form-item>
  <el-form-item label="管理名称">
    <el-input v-model="form.menuname"></el-input>
  </el-form-item>
  <el-form-item label="管理链接">
    <el-input v-model="form.linkurl"></el-input>
  </el-form-item>
  <el-form-item>
    <el-button type="primary" @click="onSubmit()">立即创建</el-button>
  </el-form-item>
</el-form>
</div>
</template>
<script>
  export default {
    props:["formdate"],
    data() {
      return {
        options:[],
        form: {
          menuId:0,
          menuname: '',
          linkurl: '',
          ParentId:0,
        }
      }
    },
    watch:{
        formdate(val)
        {
          this.GetShow();
        }
    },
    methods: {
      onSubmit() {
        this.form.ParentId=this.$refs["getParentId"].checkedValue[this.$refs["getParentId"].checkedValue.length-2];
           this.$axios.post('https://localhost:44340/api/VUE/Edit',this.form)
        .then(res =>{
            if(res.data > 0)
            {
              this.$message.success('修改成功');
              this.$emit("Edit");
            }else{
              this.$message.error('修改失败');
            }
        })
      },
      GetShow(){
        this.form.menuId = this.formdate.menuId;
        this.form.menuname = this.formdate.menuName;
        this.form.linkurl = this.formdate.linkUrl;
        this.form.ParentId = this.formdate.menuId;
        this.$axios.get('https://localhost:44340/api/VUE/GetList')
        .then(res =>{
            var reg = new RegExp('\\,"children":\\[]',"g");
        this.options = JSON.parse(JSON.stringify(res.data).replace(reg,""));
        })
      }
    },
    created(){
        this.GetShow();
    }
  }
</script>