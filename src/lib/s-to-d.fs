\ lib/s-to-d.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1824+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require dup.fs       \ `dup`
require zero-less.fs \ `0<`

get-order get-current

target-definitions

: s>d ( n -- d )
  dup 0< ;

  \ doc{
  \
  \ s>d ( n -- d ) "s-to-d"
  \
  \ Sign extend a single number _n_ to form a double number _d_.
  \
  \ See also: `d>s`, `u>ud`.
  \
  \ }doc

set-current set-order
