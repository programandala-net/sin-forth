\ lib/char-plus.fs

\ This file is part of Sin Forth.

\ This file adds `char+` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require one-plus.fs \ `1+`

get-order get-current

target-definitions

synonym char+ 1+

  \ doc{
  \
  \ char+ ( n1 -- n2 ) "char-plus"
  \
  \ Add the size in bytes of a character to _n1_, giving
  \ _n2_.
  \
  \ ``char+`` is an `alias` of `1+`.
  \
  \ See also: `char-`, `chars`.
  \
  \ }doc

set-current set-order
