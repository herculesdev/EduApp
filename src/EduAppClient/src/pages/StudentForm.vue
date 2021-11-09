<template>
  <div>
    <v-form ref="form" v-model="valid" lazy-validation>
      <v-text-field v-model="student.name" label="Name" :rules="nameRules" required />

      <v-text-field v-model="student.email" label="E-mail" :rules="emailRules" required />

      <v-text-field v-model="student.ra" label="RA" :rules="raRules" required :disabled='editMode' />

      <v-text-field v-model="student.cpf" label="CPF" :rules="cpfRules" required :disabled='editMode' />
      <p class="pt-2">
        <v-btn color="success" class="mr-4" @click="saveStudent"> Submit </v-btn>
        <v-btn color="error" class="mr-4" to="/students"> Cancel </v-btn>
      </p>
    </v-form>
  </div>
</template>

<script>
import StudentService from "../services/StudentService";

export default {
  data: () => ({
    notifications: [],
    valid: true,
    editMode: false,
    student: {
      name: "",
      email: "",
      ra: "",
      cpf: "",
    },
  }),

  async mounted() {
    let id = this.$route.params.id;

    if(id){
      var student = await StudentService.getById(id);
      if(student) {
        Object.assign(this.student, student);
        this.editMode = true;
      }
    }
  },

  computed: {
    nameRules() {
      return [!this.existsNotification('Name') || this.getNotification('Name'),]
    },
    emailRules() {
      return [!this.existsNotification('Email') || this.getNotification('Email'),]
    },
    raRules() {
      return [!this.existsNotification('RA') || this.getNotification('RA'),]
    },
    cpfRules() {
      return [!this.existsNotification('CPF') || this.getNotification('CPF'),]
    }
  },

  methods: {
    saveStudent() {
      if(this.editMode)
        this.updateStudent();
      else
        this.addStudent();
    },

    async addStudent() {
      try {
        await StudentService.add(this.student);
        this.$router.push('/students');
        this.$toasted.show("Student Added!", { 
          theme: "toasted-primary", 
          position: "top-right", 
          duration : 3000
        });
      } catch (error) {
        console.log(error);
        const notfs = await error.json();
        if (notfs) this.notifications = notfs;
        this.$refs.form.validate();
      }
    },

    async updateStudent() {
      try {
        await StudentService.update(this.student);
        this.$router.push('/students');
        this.$toasted.show("Student Updated!", { 
          theme: "toasted-primary", 
          position: "top-right", 
          duration : 3000
        });
      } catch (error) {
        console.log(error);
        const notfs = await error.json();
        if (notfs) this.notifications = notfs;
        this.$refs.form.validate();
      }
    },

    existsNotification(key) {
      return this.notifications.find(el => el.key == key) != null
    },
    getNotification(key) {
      return this.notifications.find(el => el.key == key).message
    },
  },
};
</script>

