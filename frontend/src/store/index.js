import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    login: {
      name: "pepa"
    },
    players: {
      pepa: {
        name: "pepa",
        role: "bandita",
        character: "Willie the Kid",
        lives: 4,
        cardInHand: [
          1, 2
        ],
        cardOnDesk: [
          3, 4
        ]
      },
      karel: {
        name: "karel",
        role: "sherif",
        character: "Suzy",
        lives: 4,
        cardInHand: [ 2 ],
        cardOnDesk: [ 3 ]
      }
    },
    cardsOnDesk: [ 5 ],
    packOfCardsTake: [ 6 ],
    packOfCardsLeave: [ 7 ],

    // static
    cards: {
      1: {
        type: "appaloosa",
        color: "4S"
      },
      2: {
        type: "bang",
        color: "5S"
      },
      3: {
        type: "barrel",
        color: "4K"
      },
      4: {
        type: "beer",
        color: "4K"
      },
      5: {
        type: "carabine",
        color: "4K"
      },
      6: {
        type: "catbalou",
        color: "4K"
      },
      7: {
        type: "diligenza",
        color: "4K"
      }
    },
    characters: [
      "Suzy",
      "Willie the Kid"
    ],
    roles: {
      2: {
        sherif: 1,
        bandita: 1
      },
      3: {
        sherif: 1,
        bandita: 1,
        odpadlík: 1
      },
      4: {
        sherif: 1,
        bandita: 2,
        odpadlík: 1
      },
      5: {
        sherif: 1,
        bandita: 2,
        odpadlík: 1,
        vice: 1
      },
      6: {
        sherif: 1,
        bandita: 3,
        odpadlík: 1,
        vice: 1
      },
      7: {
        sherif: 1,
        bandita: 3,
        odpadlík: 1,
        vice: 2
      }
    }
  },
  mutations: {
    moveCards: (state, payload) => { // source { type, player, place }, target, card
      var source = state[payload.source.type];
      if (payload.source.player != null && payload.source.place != null)
        source = source[payload.source.player][payload.source.place];

      var target = state[payload.target.type];
      if (payload.target.player != null && payload.target.place != null)
        target = target[payload.target.player][payload.target.place];

      var card = source.pop(payload.card);
      target.push(card);
    },
    changeLives: (state, payload) => { // count
      state.players[state.login.name].lives += payload.count;
    }
  },
  actions: {
    moveCards: (context, payload) => {
      // TODO: send
      context.commit('moveCands', payload);
    },
    changeLives: (context, payload) => {
      // TODO: send
      context.commit('changeLives', payload);
    }
  },
  modules: {
  }
})
