<template>
  <div class="role">
    {{ show ? role : "Unknown" }}
  </div>
</template>

<script>
export default {
  name: "Role",
  props: {
    player: {}
  },
  computed: {
    show() {
      return this.$store.state.login.name == this.player.name;
    },
    role() {
      return this.player.role;
    }
  }
}
</script>