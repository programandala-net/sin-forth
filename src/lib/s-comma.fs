\ lib/s-comma.fs

\ This file is part of Sin Forth.

\ This file adds `s,` to the compiler.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require allot.fs     \ `allot`
require char-plus.fs \ `char+`
require here.fs      \ `here`
require place.fs     \ `place`
require tuck.fs      \ `tuck`

get-order get-current

target-definitions

: s, ( ca len -- )
  tuck here place char+ allot ;

  \ doc{
  \
  \ s, ( ca len -- ) "s-comma"
  \
  \ Compile the string _ca len_.
  \
  \ See also: `c,`, `here`, `cmove`, `allot`, `count`.
  \
  \ }doc

set-current set-order
