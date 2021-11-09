<template>
  <div>
    <yes-no-dialog v-model="dialog" />
    <v-data-table
      :headers="headers"
      :items="students"
      :loading="tableLoading"
      loading-text="Loading students..."
      hide-default-footer
      class="elevation-1"
    >
      <template v-slot:top>
        <v-row class="d-flex align-center">
          <v-col>
            <v-text-field
              v-model="search"
              label="Search..."
              class="mx-4"
              v-on:keydown="searchKeydown"
            ></v-text-field>
          </v-col>
          <v-col>
            <v-btn color="primary" small fab dark @click="getAll">
              <v-icon>mdi-account-search</v-icon>
            </v-btn>
          </v-col>
          <v-col class="d-flex flex-row-reverse mx-4">
            <v-btn color="primary" dark class="mb-2" to="/students/create"> New Student </v-btn>
          </v-col>
        </v-row>
      </template>

      <template v-slot:item.actions="{ item }">
        <v-icon small class="mr-2" @click="editItem(item)"> mdi-pencil </v-icon>
        <v-icon small @click="deleteItem(item)"> mdi-delete </v-icon>
      </template>
    </v-data-table>
  </div>
</template>
<script>
import StudentService from "../services/StudentService";
import YesNoDialog from "../components/YesNoDialog.vue";

export default {
  components: {
    YesNoDialog,
  },

  async mounted() {
    this.getAll();
  },

  data() {
    return {
      tableLoading: false,
      search: "",
      headers: [
        { text: "ID", align: "start", value: "id" },
        { text: "Name", value: "name" },
        { text: "Email", value: "email" },
        { text: "RA", value: "ra" },
        { text: "CPF", value: "cpf" },
        { text: "Actions", value: "actions", sortable: false },
      ],
      students: [],
      dialog: {
        showDialog: false,
        title: "Title",
        text: "Text",
      },
    };
  },

  methods: {
    async getAll() {
      try {
        this.tableLoading = true;
        this.students = await StudentService.getAll(this.search);
      } catch (error) {
        console.log(error);
      } finally {
        this.tableLoading = false;
      }
    },
    async editItem(item) {
      this.$router.push(`/students/edit/${item.id}`);
    },

    async deleteItem(item) {
        this.dialog.showDialog = true;
        this.dialog.title = `Deletion #${item.id}`;
        this.dialog.text = `Do you really want to delete this record?`;
        this.dialog.yesClick = () => this.deleteItemConfirm(item);
        this.dialog.noClick = () => this.dialog.showDialog = false;
    },

    async deleteItemConfirm(item) {
      try {
        await StudentService.delete(item.id);
        await this.getAll();
        this.$toasted.show("Student Deleted!", { 
          theme: "toasted-primary", 
          position: "top-right", 
          duration : 3000
        });
      }catch(error) {
        console.log(error);
      }finally {
        this.dialog.showDialog = false;
      }
    },

    async searchKeydown(event) {
      if (event.key == "Enter") this.getAll();
    },
  },
};
</script>