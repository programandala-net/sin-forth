\ lib/pad.fs

\ This file is part of Sin Forth.

\ This file adds `pad` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require here.fs       \ `here`
require plus.fs       \ `+`
require slash-hold.fs \ `/hold`

get-order get-current

target-definitions

: pad ( -- ca )
  here /hold + ;

  \ doc{
  \
  \ pad ( -- ca )
  \
  \ _ca_ is the address of a transient region that can be used to
  \ hold data for intermediate processing. It's a fixed offset
  \ (`/hold` bytes) above `here`.
  \
  \ ``pad`` is  specifically intended as  a programmer
  \ convenience. No standard words use it.
  \
  \ See also: `/pad`.
  \
  \ }doc

set-current set-order
