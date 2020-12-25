\ lib/char-plus.fs

\ This file is part of Sin Forth.

\ This file adds `char+` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260016.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
