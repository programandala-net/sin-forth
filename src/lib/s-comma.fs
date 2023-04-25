\ lib/s-comma.fs
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

require allot.fs     \ `allot`
require char-plus.fs \ `char+`
require here.fs      \ `here`
require place.fs     \ `place`
require tuck.fs      \ `tuck`

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
