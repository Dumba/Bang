<template>
  <div class="character">
    {{ player.character }} - {{ player.lives }}
  </div>
</template>

<script>
export default {
  name: "Character",
  props: {
    player: { }
  }
}
</script>