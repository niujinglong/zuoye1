<template>
    <el-form ref="form" :model="form" label-width="80px">
  <el-form-item label="账号">
    <el-input v-model="form.UserName"></el-input>
  </el-form-item>
  <el-form-item label="密码">
    <el-input v-model="form.Password" show-password></el-input>
  </el-form-item>
  <el-form-item label="修改密码">
    <el-input v-model="xiuPwd" show-password></el-input>
  </el-form-item>
  <el-form-item label="确认密码">
    <el-input v-model="erPwd" show-password></el-input>
  </el-form-item>
   <el-form-item>
    <el-button type="primary" @click="Upd">立即创建</el-button>
    <el-button>取消</el-button>
  </el-form-item>
</el-form>
</template>
<script>
import { TimeSelect } from 'element-ui';
  export default {
    data() {
      return {
        form: {
            AdminId:'',
            UserName:'',
            Password:''
        },
        xiuPwd:'',
        erPwd:'',
        pwd:''
      }
    },
    methods: {
      onSubmit() {
        let id = location.href.substr(location.href.indexOf("=")+1);
        this.$axios.get('https://localhost:44340/api/Admins/Fan?id='+id)
        .then(res =>{
            this.form.AdminId = id;
            this.form.UserName = res.data.userName;
            this.pwd = res.data.password;
        })
      },
      Upd(){
        if(this.form.Password != this.pwd)
        {
            this.$message("您输入的密码不正确请重新填写");
            this.form.Password = "";
            return
        }
        if(this.xiuPwd == this.form.Password)
        {
            this.$message("修改的密码不能和以前的密码一致");
            return;
        }
        if(this.xiuPwd !=this.erPwd)
        {
            this.$message("修改的密码必须一致");
            return;
        }
        this.form.Password = this.form.xiuPwd;
        this.$axios.put('https://localhost:44340/api/Admins/Upd',this.form)
            .then(res =>{
                if(res.data>0)
                {
                  this.$message("修改成功");
                }
                else
                {
                  this.$message("修改失败");
                }
            })
      }
    },
    created(){
        this.onSubmit();
    }
  }
</script>