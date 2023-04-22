\ lib/s-comma.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

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
