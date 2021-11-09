<template>
  <v-dialog v-model="model.showDialog" persistent max-width="290">
    <v-card>
      <v-card-title class="text-h5">
        {{model.title}}
      </v-card-title>
      <v-card-text
        >{{model.text}}</v-card-text
      >
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="red darken-1" text @click="model.yesClick">
          Yes
        </v-btn>
        <v-btn color="green darken-1" text @click="model.noClick">
          No
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
    props: {
      value: {
        type: Object,
        default() {
          return {
            showDialog: false,
            title: 'Title',
            text: 'Question ?',
            yesClick: () => this.showDialog = false,
            noClick: () => this.showDialog = false
          }
        }
      }
    },
    data() {
        return {
            model: this.value
        }
    },
    watch: {
      model(currentValue) {
        this.$emit('input', currentValue)
      }
    }
}
</script>
