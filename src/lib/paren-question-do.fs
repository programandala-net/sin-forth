\ lib/paren-question-do.fs

\ This file is part of Sin Forth.

\ This file adds `(?do)` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012072206.
\ See change log at the end of the file.

\ ==============================================================

require d-p.fs        \ `dp`
require plus-store.fs \ `+!`

get-order get-current

target-definitions

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

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.

