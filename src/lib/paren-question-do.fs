\ lib/paren-question-do.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require d-p.fs        \ `dp`
require plus-store.fs \ `+!`

: (?do) ( -- do-sys )

  \ Credit:
  \ Code adapted from Solo Forth,
  \ originally based on Spectrum Forth-83.

  \ pop hl       ; HL = init
  \ pop de       ; DE = limit
  \ and a
  \ sbc hl,de    ; init=limit?
  \ jp z,branch_ ; if so, skip the loop
  \ add hl,de    ; reverse the substraction
  \ jp paren_do.de_hl

  \ doc{
  \
  \ (?do ( n1|u1 n2|u2 -- ) ( R: -- loop-sys | ) "paren-question-do"
  \
  \ If _n1|u1_ is equal to _n2|u2_, continue execution at the
  \ location given by the consumer of the _do-sys_ left by `?do`
  \ at compilation time.  Otherwise set up loop control parameters
  \ _loop-sys_ with index _n2|u2_ and limit _n1|u1_ and continue
  \ executing immediately following `?do`.  Anything  already on
  \ the  return stack becomes unavailable until the loop control
  \ parameters _loop_sys_ are discarded.
  \
  \ ``(?do`` is compiled by `?do`.
  \
  \ See also: `(do`, `(-do`.
  \
  \ }doc
